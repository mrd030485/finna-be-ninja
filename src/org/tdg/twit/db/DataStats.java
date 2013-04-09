package org.tdg.twit.db;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import org.apache.log4j.Logger;

public class DataStats {
  Logger                    logger      = Logger.getLogger(DataStats.class);
  private String            selectCount = "SELECT COUNT(*) FROM raw_twitter_posts where processed = 0";
  private Connection        connect     = null;
  private PreparedStatement prepStmt    = null;
  private ResultSet         rs          = null;

  public DataStats(Connection conn) {
    connect = conn;
  }

  public int getDBRowCount() {
    if (connect == null) {
      logger.error(DataStats.class.getName() + ": Database connection is closed");
    }
    try {
      Class.forName("com.mysql.jdbc.Driver");
      prepStmt = connect.prepareStatement(selectCount);
      rs = prepStmt.executeQuery();
      if (rs.next()) {
        return rs.getInt(1);
      }
    } catch (ClassNotFoundException e) {
      logger.debug(DataStats.class.getName() + ": " + e.getMessage());
    } catch (SQLException e) {
      logger.debug(DataStats.class.getName() + ": " + e.getMessage());
    }

    return -1;
  }
  public void close(){
    try{
      connect.close();
    }catch(SQLException ignore){
    }
  }
}
