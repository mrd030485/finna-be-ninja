package org.tdg.twit.db;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Blob;

import java.util.ArrayList;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

import org.apache.log4j.Logger;

public class ManageProcess extends Thread {
	ExecutorService pool = Executors.newFixedThreadPool(5);
	Logger logger = Logger.getLogger(ManageProcess.class);

	public ManageProcess(Connection conn) {
		super("Manage Process Thread");
		this.connect = conn;
		start();
	}

	private String selectCount = "SELECT COUNT(*) FROM raw_twitter_posts where processed = 0";
	private String selectRecordsToProcess = "SELECT id,rawdata FROM raw_twitter_posts WHERE processed = 0 order by id asc limit ?,500";
	private String setProcessed = "UPDATE raw_twitter_posts set processed=1, process_date=NOW() where id>=? AND id <=?";
	private Connection connect = null;
	private PreparedStatement prepStmt = null;
	private ResultSet rs = null;
	private int startId = -1;
	private int endId = -1;
	public void run() {
		logger.debug("Start counting records to be processed");
		if (connect == null) {
			logger.error(ManageProcess.class.getName()
					+ ": Database connection is not open");
		}
		ResultSet shut;
		try {
			shut = connect.prepareStatement("select status from settings where name='shutdown'").executeQuery();
		
		shut.first();
		while (shut.getInt(1)==0) {
			try {
				Class.forName("com.mysql.jdbc.Driver");
				prepStmt = connect.prepareStatement(selectCount);
				rs = prepStmt.executeQuery();
				if (rs.next()) {
					int count = rs.getInt(1);
					rs.close();
					prepStmt.close();
					for (int i = 0; i < (Math.ceil(count / 500)); i=i+1) {
						prepStmt = connect
								.prepareStatement(selectRecordsToProcess);
						prepStmt.setInt(1, i);
						rs = prepStmt.executeQuery();
						ArrayList<Blob> rsAr = new ArrayList<>();
						while (rs.next()) {
							if (startId == -1) {
								startId = rs.getInt(1);
							} else {
								endId = rs.getInt(1);
							}
							rsAr.add(rs.getBlob(2));
						}
						logger.info("There have been: "+i*500+" records processed");
						pool.submit(new ProcessPosts(rsAr, connect));
						rs.close();
						prepStmt.close();
					}
				}
				rs.close();
				prepStmt.close();
				prepStmt = connect.prepareStatement(setProcessed);
				prepStmt.setInt(1, startId);
				prepStmt.setInt(2, endId);
				prepStmt.execute();
			} catch (SQLException e) {
				logger.error(ManageProcess.class.getName()+" "+e.getMessage());
			} catch (ClassNotFoundException e) {
				logger.error(ManageProcess.class.getName()+" "+e.getMessage());
			}
			shut = connect.prepareStatement("select status from settings where name='shutdown'").executeQuery();
			shut.first();
		}
		} catch (SQLException e1) {
			logger.error(ManageProcess.class.getName()+": "+e1.getMessage());
		}
		pool.shutdown();
		try {
			pool.awaitTermination(180000, TimeUnit.MILLISECONDS);
		} catch (InterruptedException e) {
			logger.error(ManageProcess.class.getName()+": "+e.getMessage());
		}
	}

}
