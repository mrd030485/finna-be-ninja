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
	private Connection connect = null;
	private PreparedStatement prepStmt = null;
	public EnqueueTwitterPosts(String data, Connection conn){
		super("Transform "+data+" thread");
		logger.debug("Start Transform thread for "+data);
		if(data!=null){
			this.data = data;
		}else{
			this.data="-1";
		}
	  this.connect = conn;
    start();
	}
	
	public void run(){
    if(connect==null){
      logger.error(EnqueueTwitterPosts.class.getName()+": Database connection is closed");
    }
    try {
			Class.forName("com.mysql.jdbc.Driver");
			logger.debug("Inserting data into DB");

      prepStmt = connect.prepareStatement(insertQuery);
			
			Blob blob = new SerialBlob(data.getBytes());
			prepStmt.setBlob(1, blob);
			prepStmt.setBoolean(2, false);			
			
			logger.debug("Executing insert");
			prepStmt.execute();
		  prepStmt.close();
    } catch (SQLException e) {
			logger.error(e.getMessage());
		} catch (ClassNotFoundException e) {
			logger.error(e.getMessage());
		}
  } 
}
