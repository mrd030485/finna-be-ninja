package org.tdg.twit.main;

import org.apache.log4j.*;
import org.apache.log4j.xml.DOMConfigurator;
import org.tdg.twit.db.ManageProcess;
import org.tdg.twit.inbound.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class FpClassifier {

	/**
	 * @param args
	 */

	static Logger logger = Logger.getLogger(FpClassifier.class);
	static ExecutorService pool = Executors.newFixedThreadPool(3);
	private static String statsQuery1 = "SELECT IFNULL( count( rp.status ) / count( raw.rawdata ) , 0 ) AS percentRecovered "
			+ "FROM recovered_statuses rp, raw_twitter_posts raw WHERE true";

	public static void main(String[] args) {
		Connection gatherConn = null;
		Connection processConn = null;
		Connection localConn = null;

		boolean shutdown = false;
		boolean dl = true;

		DOMConfigurator.configure(FpClassifier.class.getClassLoader()
				.getResource("log4j.xml"));
		logger.info("Starting app");

		String user = null;
		String password = null;
		String url = "jdbc:mysql://192.168.1.87:3306/fpclassifier_production";

		if (args.length != 2) {

			System.err
					.println("Wrong arguments supplied: Example -- java -jar fpclassifier user password");
			logger.error(FpClassifier.class.getName()
					+ ": Wrong arguments supplied: Example -- java -jar fpclassifier user password");
			System.exit(1);

		} else {

			user = args[0];
			password = args[1];

		}

		try {

			Class.forName("com.mysql.jdbc.Driver");

			gatherConn = DriverManager.getConnection(url, "fpclass", null);
			processConn = DriverManager.getConnection(url, "fpclass", null);
			localConn = DriverManager.getConnection(url, "fpclass", null);

			ResultSet shut = localConn.prepareStatement(
					"select status from settings where name='shutdown'")
					.executeQuery();
			ResultSet rs = localConn
					.prepareStatement(
							"select status from settings where name='download_statuses'")
					.executeQuery();

			if (rs.next() && shut.next()) {
				shutdown = shut.getInt(1) == 0;
				dl = rs.getInt(1) == 1;
			} else {
				shutdown = false;
				dl = true;
			}
			shut.close();
			rs.close();
			pool.submit(new Gather(user, password, gatherConn));
			pool.submit(new ManageProcess(processConn));
			while (!shutdown) {
				shut = localConn.prepareStatement(
						"select status from settings where name='shutdown'")
						.executeQuery();
				rs = localConn
						.prepareStatement(
								"select status from settings where name='download_statuses'")
						.executeQuery();
				if (rs.next() && shut.next()) {
					shutdown = shut.getInt(1) == 0;
					dl = rs.getInt(1) == 1;
				} else {
					shutdown = false;
					dl = true;
				}
				if (shutdown) {
					logger.info("System is shutting down");
					logger.debug("System is shutting down");
				}
				if (!dl) {
					logger.info("No posts will be downloaded from twitter");
					logger.debug("No posts will be downloaded from twitter");
				}
				ResultSet stats = localConn.prepareStatement(statsQuery1)
						.executeQuery();
				if (stats.first()) {
					logger.info(FpClassifier.class.getName() + ": Statistics");
					logger.info("\t Percentage of usable posts: "
							+ stats.getFloat(1));
					/*
					 * logger.info("\t Percentage of posts downloaded w/Keyword: "
					 * + stats.getFloat(3));
					 * logger.info("\t Percentage of posts from users w/Keyword: "
					 * + stats.getFloat(2)); logger.info(
					 * "\t if the last number is not 1 then there is an issue with the systems post submissions"
					 * );
					 */
				}
			}
		} catch (SQLException e) {
			logger.error(e.getMessage());
		} catch (ClassNotFoundException e) {
			logger.error(e.getMessage());
		} finally {
			try {
				pool.shutdown();
				pool.awaitTermination(5, TimeUnit.MINUTES);
			} catch (InterruptedException e) {
				logger.error(e.getMessage());
			} finally {
				try {
					gatherConn.close();
					processConn.close();
					localConn.close();
				} catch (SQLException e) {
					// This is ok with me.
				}
			}

		}
	}
}
