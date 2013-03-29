package org.tdg.twit.db;

import java.sql.Blob;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import org.apache.log4j.Logger;

import twitter4j.HashtagEntity;
import twitter4j.Status;
import twitter4j.TwitterException;
import twitter4j.json.DataObjectFactory;

import com.google.gson.Gson;

public class ProcessPosts extends Thread {
	Logger logger = Logger.getLogger(ProcessPosts.class);
	public ProcessPosts(String url,String user, String pw){
		super("Process Posts Thread");
		logger.info("Process Posts Thread created");
		if(url!=null){
			this.url = url;
		}
		if(user!=null){
			this.user=user;
		}
		if(pw!=null){
			this.pw=pw;
		}
		start();
	}
	private String url = "jdbc:mysql://192.168.1.87:3306/fpclassifier_development";
	private String user = "fpclass";
	private String pw = null;
	private String retrieveResult = "SELECT * FROM raw_twitter_posts where processed = 0 order by id limit ?,1";
	private String selectCount = "SELECT COUNT(*) FROM raw_twitter_posts where processed = 0";
	private String setProcessed = "UPDATE raw_twitter_posts set processed=1, process_date=NOW() where id=?";
	private String insertStatusRecord = "INSERT INTO recovered_statuses (status,keywords,created_at,updated_at) values (?,?,NOW(),NOW())";
	private Connection connect = null;
	private PreparedStatement prepStmt = null;
	private ResultSet rs = null;
	public void run(){
		
			try {
				Class.forName("com.mysql.jdbc.Driver");
				logger.debug("Creating DB connection");
				connect = DriverManager.getConnection(url, user, pw);
				prepStmt = connect.prepareStatement(selectCount);
				rs = prepStmt.executeQuery();
				if(rs.next()){
					int count = rs.getInt(1);
					prepStmt.close();
					rs.close();
					for(int i=0; i<count; i++){
						prepStmt = connect.prepareStatement(retrieveResult);
						prepStmt.setInt(1, i);
						rs = prepStmt.executeQuery();
						if(rs.next()){
							Blob blob = rs.getBlob("rawdata");
							int id = rs.getInt("id");
							

							rs.close();
							prepStmt.close();
							
							/**
							 * Convert incoming data into twitter status 
							 * remove hashtags and format string in keyword<endofhashtag/>...keyword<endofhashtag/>
							 * 
							 * insert data into recovered_statuses table
							 * 
							 */
							
							String data = new String(blob.getBytes(1, (int)blob.length()));
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
							
							/**
							 * Update raw table to processed
							 */
							
							prepStmt = connect.prepareStatement(setProcessed);
							prepStmt.setInt(1, id);
							prepStmt.execute();
							prepStmt.close();
						}
					}
				}
				
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
