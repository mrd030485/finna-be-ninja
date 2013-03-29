package org.tdg.twit.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import org.apache.log4j.Logger;

public class DataStats {
	Logger logger = Logger.getLogger(DataStats.class);
	private String url = "jdbc:mysql://192.168.1.87:3306/fpclassifier_development";
	private String user = "fpclass";
	private String pw = null;
	private String selectCount = "SELECT COUNT(*) FROM raw_twitter_posts where processed = 0";
	private Connection connect = null;
	private PreparedStatement prepStmt = null;
	private ResultSet rs = null;
	public DataStats(String url,String user,String pw){
		if(url!=null){
			this.url=url;
		}
		if(user!=null){
			this.user=user;
		}
		if(pw!=null){
			this.pw=pw;
		}
	}
	public int getDBRowCount(){
		logger.debug("Get number of rows in db");
		try {
			logger.debug("Creating DB connection");
			Class.forName("com.mysql.jdbc.Driver");
			connect = DriverManager.getConnection(url, user, pw);
			prepStmt = connect.prepareStatement(selectCount);
			rs = prepStmt.executeQuery();
			if(rs.next()){
				return rs.getInt(1);
			}
		} catch (ClassNotFoundException e) {
			logger.debug(e.getMessage());
		} catch (SQLException e) {
			logger.debug(e.getMessage());
		}
		
		return -1;
	}
}
