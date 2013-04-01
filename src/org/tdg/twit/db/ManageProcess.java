package org.tdg.twit.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import org.apache.log4j.Logger;

public class ManageProcess extends Thread {
	Logger logger = Logger.getLogger(ManageProcess.class);

	public ManageProcess(Connection conn) {
		super("Manage Process Thread");
    this.connect = conn;
		start();
	}

	private String selectCount = "SELECT COUNT(*) FROM raw_twitter_posts where processed = 0";
  private String selectRecordsToProcess = "SELECT id,rawdata FROM raw_twitter_posts WHERE processed = 0 order by id asc limit ?,1000";
  private Connection connect = null;
	private PreparedStatement prepStmt = null;
	private ResultSet rs = null;

	public void run() {
		logger.debug("Start counting records to be processed");
    if(connect==null){
    logger.error(ManageProcess.class.getName()+": Database connection is not open");  
    }
		while (true) {
			try {
				Class.forName("com.mysql.jdbc.Driver");
				prepStmt = connect.prepareStatement(selectCount);
				rs = prepStmt.executeQuery();
				if(rs.next()){
					int count = rs.getInt(1);
          rs.close();
          prepStmt.close();
          int startId=-1;
          int endId=-1;
          for(int i=0; i<(Math.ceil(count/1000)); i++){
            prepStmt = connect.prepareStatement(selectRecordsToProcess);
            prepStmt.setInt(1,i);
						rs = prepStmt.executeQuery();
            if(rs.next()){
              if(startId==-1){
                startId=rs.getInt(1);
              }else{
                rs.last();
                endId=rs.getInt(1);
              }
              rs.first();
              Thread t = new ProcessPosts(rs.getArray(2),connect);					
              System.out.println("here2");
            }
            rs.close();
            prepStmt.close();
					}
				}
				rs.close();
				prepStmt.close();
				connect.close();
			} catch (SQLException e) {
				logger.error(e.getMessage());
			} catch (ClassNotFoundException e) {
				logger.error(e.getMessage());
			}
		}
	}

}
