package org.tdg.twit.processing;

import java.sql.Blob;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.ArrayList;

import org.apache.log4j.Logger;

import twitter4j.HashtagEntity;
import twitter4j.Status;
import twitter4j.TwitterException;
import twitter4j.json.DataObjectFactory;

public class ProcessPosts extends Thread {
  Logger logger = Logger.getLogger(ProcessPosts.class);

  public ProcessPosts(ArrayList<Blob> rs) {
    this.allResults = rs;
    start();
  }

  private String            insertStatusRecord = "INSERT INTO recovered_statuses (status,keywords,created_at,updated_at,processed) values ";
  private Connection        connect            = null;
  private PreparedStatement prepStmt           = null;
  private ArrayList<Blob>   allResults         = null;
  public static final String DRIVER      = "com.mysql.jdbc.Driver";
  public static final String URLDB       = "jdbc:mysql://192.168.1.87:3306/fpclassifier_production";
  public static final String USERNAMEDB  = "fpclass";
  public static final String PASSWORDDB  = null;

  public void run() {
    if (allResults == null) {
      logger.error(ProcessPosts.class.getName()
          + ": Result set is empty or does not exists");
    }
    try {
      Class.forName(DRIVER).newInstance();
      connect = DriverManager.getConnection(URLDB, USERNAMEDB, PASSWORDDB);
      StringBuilder sb = new StringBuilder(insertStatusRecord);

      Boolean firstAppend = true;

      while (!allResults.isEmpty()) {
        Blob blob = allResults.get(0);
        allResults.remove(0);
        /**
         * Convert incoming data into twitter status remove hashtags and format
         * string in keyword<endofhashtag/>...keyword<endofhashtag/>
         * 
         * insert data into recovered_statuses table
         * 
         */

        String data = new String(blob.getBytes(1, (int) blob.length()));
        if (data != null) {
          if (!data.startsWith("{\"delete\":")) {
            Status status = DataObjectFactory.createStatus(data);
            HashtagEntity[] hashtags = status.getHashtagEntities();
            StringBuilder hashtagXM = new StringBuilder();
            if (hashtags != null) {
              for (int j = 0; j < hashtags.length; j++) {
                hashtagXM.append(hashtags[j].getText() + "<endofhashtag/>");
              }
            }
            String ht = hashtagXM.toString();
            ht=ht.trim();
            if(ht.isEmpty()||ht==null||ht.equals("<endofhashtag/>")){
              //skip
            }else{
              String statusText = normalizeStatus(status.getText().toLowerCase());
              if (statusText != null) {
                if (firstAppend) {
                  sb.append("('" + statusText + "','" + ht.toLowerCase() + "',NOW(),NOW(),0)");
                  firstAppend = false;
                } else {
                  sb.append(", ('" + statusText + "','" + ht.toLowerCase() + "',NOW(),NOW(),0)");
                }
              }
            }
            
          }
        }
      }// End of while loop
      prepStmt = connect.prepareStatement(sb.toString());
      prepStmt.executeUpdate();
      prepStmt.close();
    } catch (ClassNotFoundException e) {
      logger.error(ProcessPosts.class.getName() + "MySql:JDBC:CONNECTOR - "
          + e.getMessage());
    } catch (SQLException e) {
      logger.error(ProcessPosts.class.getName() + " SQL error - "
          + e.getMessage());
    } catch (TwitterException e) {
      logger.error(ProcessPosts.class.getName() + "Twitter post error - "
          + e.getMessage() + " ::-:: " + e.getErrorMessage());
    } catch (InstantiationException e) {
      // TODO Auto-generated catch block
      e.printStackTrace();
    } catch (IllegalAccessException e) {
      // TODO Auto-generated catch block
      e.printStackTrace();
    }finally{
      try {
        prepStmt.close();
        connect.close();
      } catch (SQLException e) {
      }
    }
  }

  private String normalizeStatus(String statusText) {
    if (statusText != null) {
      int url = statusText.indexOf("http");
      int urlend = statusText.indexOf(" ", url);
      while (statusText.contains("http")) {
        if (urlend != -1) {
          statusText = statusText.substring(0, url)
              + statusText.substring(urlend);
        } else if (url != -1) {
          statusText = statusText.substring(0, url);
        }
        url = statusText.indexOf("http");
        urlend = statusText.indexOf(" ", url);
      }
      statusText = statusText.replaceAll("[^0-9a-zA-Z'\\s]", " ");
      statusText = statusText.replaceAll("( )+", " ");
      statusText = statusText.replaceAll("'", "");
    }
    return statusText;
  }
}
