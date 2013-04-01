package org.tdg.twit.db;

import java.sql.Blob;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Array;

import org.apache.log4j.Logger;

import twitter4j.HashtagEntity;
import twitter4j.Status;
import twitter4j.TwitterException;
import twitter4j.json.DataObjectFactory;


public class ProcessPosts extends Thread {
	Logger logger = Logger.getLogger(ProcessPosts.class);
	public ProcessPosts(Array rs, Connection conn){
		super("Process Posts Thread");
		logger.info("Process Posts Thread created");
		this.allResults = rs;
    this.connect = conn;
    start();
	}
	private String insertStatusRecord = "INSERT INTO recovered_statuses (status,keywords,created_at,updated_at) values (?,?,NOW(),NOW())";
	private Connection connect = null;
	private PreparedStatement prepStmt = null;
  private Array allResults = null;
  private ResultSet rs = null;
	public void run(){
      System.out.println("here1");
		  if(allResults==null){
        logger.error(ProcessPosts.class.getName()+": Result set is empty or does not exists");
      System.out.println("here2");
      }else if(connect==null){
        logger.error(ProcessPosts.class.getName()+": Database connection is closed");
      System.out.println("here3");
      }
			try {
				Class.forName("com.mysql.jdbc.Driver");
        rs = allResults.getResultSet();
        while(rs.next()){
          Blob blob = rs.getBlob(1);
          /**
           * Convert incoming data into twitter status 
           * remove hashtags and format string in keyword<endofhashtag/>...keyword<endofhashtag/>
           * 
           * insert data into recovered_statuses table
           * 
           */
            
          String data = new String(blob.getBytes(1, (int)blob.length()));
          System.out.println(data);
          if(!data.startsWith("{\"delete\":")){
            Status status = DataObjectFactory.createStatus(data);
            if(status.getUser().getLang().startsWith("en")){
              HashtagEntity[] hashtags = status.getHashtagEntities();
              StringBuilder hashtagXM = new StringBuilder();
              if(hashtags!=null){
                for(int j=0; j<hashtags.length; j++){
                  hashtagXM.append(hashtags[j].getText()+"<endofhashtag/>");
                }
              }
									
              prepStmt = connect.prepareStatement(insertStatusRecord);
              String statusText = normalizeStatus(status.getText().toLowerCase());
              
              prepStmt.setString(1, statusText);
              prepStmt.setString(2, hashtagXM.toString());
              prepStmt.execute();
              prepStmt.close();
            }
          }
        }//End of while loop
			} catch (ClassNotFoundException e) {
				logger.error("MySql:JDBC:CONNECTOR - "+e.getMessage());
			} catch (SQLException e) {
				logger.error("SQL error - "+e.getMessage());
			} catch (TwitterException e) {
				logger.error("Twitter post error - "+e.getMessage()+" ::-:: "+e.getErrorMessage());
			}finally{
				if(connect!=null){
					try {
						connect.close();
					} catch (SQLException e) {
						// this is ok
						e.printStackTrace();
					}
				}
			}
	}
	private String normalizeStatus(String statusText){
		int url = statusText.indexOf("http");
		int urlend = statusText.indexOf(" ", url);
		while(statusText.contains("http")){
			if(urlend!=-1){
				statusText = statusText.substring(0, url)+statusText.substring(urlend);
			}else if(url!=-1){
				statusText = statusText.substring(0, url);
			}
			url = statusText.indexOf("http");
			urlend = statusText.indexOf(" ", url);	
		}
		statusText = statusText.replaceAll("[^0-9a-zA-Z'\\s]", "");
		statusText = statusText.replaceAll("( )+"," ");
		return statusText;
	}
}
