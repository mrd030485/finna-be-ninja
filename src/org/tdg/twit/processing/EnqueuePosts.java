package org.tdg.twit.processing;

import java.sql.Blob;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

import org.apache.log4j.Logger;
import javax.sql.rowset.serial.SerialBlob;

public class EnqueuePosts extends Thread {

  static Logger              logger      = Logger
                                             .getLogger(EnqueuePosts.class);

  private String[]           data;
  private String             insertQuery = "insert into raw_twitter_posts (rawdata,created_at,updated_at,processed)";
  private Connection         connect     = null;
  private PreparedStatement  prepStmt    = null;
  public static final String DRIVER      = "com.mysql.jdbc.Driver";
  public static final String URLDB       = "jdbc:mysql://192.168.1.87:3306/fpclassifier_production";
  public static final String USERNAMEDB  = "fpclass";
  public static final String PASSWORDDB  = null;

  public EnqueuePosts(String[] data) {
    if (data != null) {
      this.data = data;
    }
    start();
  }

  public void run() {
    try {
      Class.forName(DRIVER).newInstance();
      connect = DriverManager.getConnection(URLDB, USERNAMEDB, PASSWORDDB);
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
          blob = null;
        }
        prepStmt.executeUpdate();
        prepStmt.close();
      }
      sb = null;
    } catch (SQLException e) {
      logger.error(EnqueuePosts.class.getName() + " " + e.getMessage());
    } catch (ClassNotFoundException e) {
      logger.error(EnqueuePosts.class.getName() + " " + e.getMessage());
    } catch (InstantiationException e) {
      // TODO Auto-generated catch block
      e.printStackTrace();
    } catch (IllegalAccessException e) {
      // TODO Auto-generated catch block
      e.printStackTrace();
    } finally {
      try {
        prepStmt.close();
        connect.close();
        connect.close();
      } catch (SQLException ignore) {
      }
    }
  }
}
