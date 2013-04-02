package org.tdg.twit.main;

import org.apache.log4j.*;
import org.tdg.twit.db.ManageProcess;
import org.tdg.twit.inbound.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class FpClassifier {

	/**
	 * @param args
	 */

	static Logger logger = Logger.getLogger(FpClassifier.class);

	public static void main(String[] args) {
		Connection conn = null;
		Thread gatherThread = null;
		Thread manageThread = null;
		PropertyConfigurator.configure(FpClassifier.class.getClassLoader()
				.getResource("log4j.properties"));
		logger.info("Starting app");
		String user = null;
		String password = null;
		String url = "jdbc:mysql://192.168.1.87:3306/fpclassifier_development";
		if (args.length != 2) {
			System.err
					.println("Wrong arguments supplied: Example -- java -jar fpclassifier user password");
			logger.error("Wrong arguments supplied: Example -- java -jar fpclassifier user password");
			System.exit(1);
		} else {
			user = args[0];
			password = args[1];
		}
		try {
			Class.forName("com.mysql.jdbc.Driver");
			conn = DriverManager.getConnection(url, "fpclass", null);
			ResultSet shut = conn.prepareStatement("select status from settings where name='shutdown'").executeQuery();
			shut.first();
			while (shut.getInt(1) != 1) {
				shut.close();
				PreparedStatement p = conn.prepareStatement("select status from settings where name='download_statuses'");
				ResultSet rs = p.executeQuery();
				if (rs.next()) {
					if (rs.getInt(1) == 1) {
						if (gatherThread == null
								|| gatherThread.getState() == Thread.State.NEW
								|| gatherThread.getState() == Thread.State.TERMINATED) {
							gatherThread = new Gather(user, password, conn);
						}
					} else {
						gatherThread.stop();
						gatherThread = null;
					}
					rs.close();
				} else {
					gatherThread = new Gather(user, password, conn);
				}
				if (manageThread == null
						|| manageThread.getState() == Thread.State.TERMINATED) {
					manageThread = new ManageProcess(conn);
				}
				shut = conn.prepareStatement("select status from settings where name='shutdown'").executeQuery();
				shut.first();
			}
			gatherThread.stop();
		} catch (SQLException e) {
			logger.error(e.getMessage());
		} catch (ClassNotFoundException e) {
			logger.error(e.getMessage());
		} finally {
			try {
				gatherThread.join();
				manageThread.join();
			} catch (InterruptedException e) {
				logger.error(e.getMessage());
			} finally {
				try {
					conn.close();
				} catch (SQLException e) {
					// This is ok with me.
				}
			}

		}
	}
}
