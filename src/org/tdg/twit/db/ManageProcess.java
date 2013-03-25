package org.tdg.twit.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import org.apache.log4j.Logger;

public class ManageProcess extends Thread {
	Logger logger = Logger.getLogger(ManageProcess.class);

	public ManageProcess() {
		super("Manage Process Thread");
		start();
	}

	private String url = "jdbc:mysql://127.0.0.1:3306/fpclassifier_development";
	private String user = "fpclass";
	private String pw = null;
	private String selectCount = "SELECT COUNT(*) FROM raw_twitter_posts where processed = 0";
	private Connection connect = null;
	private PreparedStatement prepStmt = null;
	private ResultSet rs = null;

	public void run() {
		logger.debug("Start counting records to be processed");
		while (true) {
			try {
				Class.forName("com.mysql.jdbc.Driver");
				connect = DriverManager.getConnection(url, user, pw);
				prepStmt = connect.prepareStatement(selectCount);
				rs = prepStmt.executeQuery();
				if(rs.next()){
					int count = rs.getInt(1);
					if(count>5000){
						Thread t = new ProcessPosts(url,user,pw);
						t.join();
					}
				}
				rs.close();
				prepStmt.close();
				connect.close();
			} catch (SQLException e) {
				logger.error(e.getMessage());
			} catch (ClassNotFoundException e) {
				logger.error(e.getMessage());
			} catch (InterruptedException e) {
				logger.error(e.getMessage());
			}
		}
	}

}
