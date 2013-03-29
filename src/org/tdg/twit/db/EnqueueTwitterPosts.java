package org.tdg.twit.db;

import java.sql.Blob;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import org.apache.log4j.Logger;
import javax.sql.rowset.serial.SerialBlob;


public class EnqueueTwitterPosts extends Thread{
	
	static Logger logger = Logger.getLogger(EnqueueTwitterPosts.class);
	
	private String data;
	private String insertQuery = "insert into raw_twitter_posts (rawdata,created_at,updated_at,processed) values(?,NOW(),NOW(),?)";
	private String url = "jdbc:mysql://192.168.1.87:3306/fpclassifier_development";
	private Connection connect = null;
	private PreparedStatement prepStmt = null;
	public EnqueueTwitterPosts(String data, String url){
		super("Transform "+data+" thread");
		logger.debug("Start Transform thread for "+data);
		if(data!=null){
			this.data = data;
		}else{
			this.data="-1";
		}
		if(url!=null){
			this.url=url;
		}
		start();
	}
	
	public void run(){
		try {
			Class.forName("com.mysql.jdbc.Driver");
			logger.debug("Creating DB connection");
			connect = DriverManager.getConnection(url, "fpclass", null);
			prepStmt = connect.prepareStatement(insertQuery);
			
			Blob blob = new SerialBlob(data.getBytes());
			prepStmt.setBlob(1, blob);
			prepStmt.setBoolean(2, false);			
			
			logger.debug("Executing insert");
			prepStmt.execute();
		} catch (SQLException e) {
			logger.error(e.getMessage());
		} catch (ClassNotFoundException e) {
			logger.error(e.getMessage());
		}finally{

			try {
				logger.debug("Closing DB connection");
				connect.close();
			} catch (SQLException e) {
				//I am ok with this error
			}
		}
	}

}
