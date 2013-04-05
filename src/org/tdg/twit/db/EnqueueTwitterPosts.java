package org.tdg.twit.db;

import java.sql.Blob;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import org.apache.log4j.Logger;
import javax.sql.rowset.serial.SerialBlob;

public class EnqueueTwitterPosts implements Runnable {

	static Logger logger = Logger.getLogger(EnqueueTwitterPosts.class);

	private String[] data;
	private String insertQuery = "insert into raw_twitter_posts (rawdata,created_at,updated_at,processed)";
	private Connection connect = null;
	private PreparedStatement prepStmt = null;

	public EnqueueTwitterPosts(String[] data, Connection conn) {
		if (data != null) {
			this.data = data;
		}
		this.connect = conn;
	}

	public void run() {
		if (connect == null) {
			logger.error(EnqueueTwitterPosts.class.getName()
					+ ": Database connection is closed");
		}
		try {
			Class.forName("com.mysql.jdbc.Driver");
			logger.debug("Inserting data into DB");

			StringBuilder sb = new StringBuilder();
			sb.append(insertQuery);
			for (int i = 0; i < data.length; i++) {
				if (i == 0) {
					sb.append(" values(?,NOW(),NOW(),0)");
				} else {
					sb.append(",(?,NOW(),NOW(),0)");
				}
			}
			if (sb.toString() != null) {
				prepStmt = connect.prepareStatement(sb.toString());
				for (int t = 0; t < data.length; t = t + 1) {
					Blob blob = null;
					if (data[t] != null) {
						blob = new SerialBlob(data[t].getBytes());
					}
					prepStmt.setBlob(t + 1, blob);
				}
				prepStmt.executeUpdate();
				prepStmt.close();
			}
			sb = null;
		} catch (SQLException e) {
			logger.error(EnqueueTwitterPosts.class.getName() + " "
					+ e.getMessage());
		} catch (ClassNotFoundException e) {
			logger.error(EnqueueTwitterPosts.class.getName() + " "
					+ e.getMessage());
		}
	}
}
