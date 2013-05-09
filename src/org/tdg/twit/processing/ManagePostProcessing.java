package org.tdg.twit.processing;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Blob;
import javax.sql.DataSource;
import java.util.ArrayList;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

import org.apache.log4j.Logger;

public class ManagePostProcessing implements Runnable {
  Logger                    logger    = Logger.getLogger(ManagePostProcessing.class);
  private ArrayList<Thread> processes = null;

  public ManagePostProcessing() {
    processes = new ArrayList<>();
  }

  private String            selectCount            = "SELECT COUNT(*) FROM raw_twitter_posts where processed = 0";
  private String            selectRecordsToProcess = "SELECT id,rawdata FROM raw_twitter_posts WHERE processed = 0 order by id asc limit ?,500";
  private String            setProcessed           = "UPDATE raw_twitter_posts set processed=1, process_date=NOW() where id>=? AND id <=?";
  private Connection        connect                = null;
  private PreparedStatement prepStmt               = null;
  private ResultSet         rs                     = null;
  private ResultSet         shut                   = null;
  private int               startId                = -1;
  private int               endId                  = -1;
  public static final String DRIVER = "com.mysql.jdbc.Driver";
  public static final String URLDB = "jdbc:mysql://192.168.1.87:3306/fpclassifier_production";
  public static final String USERNAMEDB = "fpclass";
  public static final String PASSWORDDB = null;
  

  public void run() {
    logger.debug("Start counting records to be processed");
    try {
      Class.forName(DRIVER).newInstance();
      connect = DriverManager.getConnection(URLDB, USERNAMEDB, PASSWORDDB);
      shut = connect.prepareStatement("select status from settings where name='shutdown'").executeQuery();

      shut.first();
      while (shut.getInt(1) == 0 && !connect.isClosed()) {
        try {
          prepStmt = connect.prepareStatement(selectCount);
          rs = prepStmt.executeQuery();
          if (rs.next()) {
            int count = rs.getInt(1);
            rs.close();
            prepStmt.close();
            for (int i = 0; i < (Math.ceil(count / 200)); i = i + 1) {
              prepStmt = connect.prepareStatement(selectRecordsToProcess);
              prepStmt.setInt(1, i);
              rs = prepStmt.executeQuery();
              ArrayList<Blob> rsAr = new ArrayList<>();
              while (rs.next()) {
                if (startId == -1) {
                  startId = rs.getInt(1);
                } else {
                  endId = rs.getInt(1);
                }
                rsAr.add(rs.getBlob(2));
              }
              logger.info("There have been: " + (i+1) * 200 + " records processed");
              processes.add(new ProcessPosts(rsAr));
              rs.close();
              prepStmt.close();
              if(processes.size()>2){
                while(!processes.isEmpty()){
                  try {
                    processes.remove(0).join();
                  } catch (InterruptedException e) {
                  }
                }
              }
            }
          }
          while(!processes.isEmpty()){
            try {
              processes.remove(0).join();
            } catch (InterruptedException e) {
            }
          }
          rs.close();
          prepStmt.close();
          prepStmt = connect.prepareStatement(setProcessed);
          prepStmt.setInt(1, startId);
          prepStmt.setInt(2, endId);
          prepStmt.execute();
        } catch (SQLException e) {
          logger.error(ManagePostProcessing.class.getName() + " " + e.getMessage());
        }
        shut = connect.prepareStatement("select status from settings where name='shutdown'").executeQuery();
        shut.first();
      }
    } catch (SQLException e1) {
      logger.error(ManagePostProcessing.class.getName() + ": " + e1.getMessage());
    } catch (InstantiationException e1) {
      // TODO Auto-generated catch block
      e1.printStackTrace();
    } catch (IllegalAccessException e1) {
      // TODO Auto-generated catch block
      e1.printStackTrace();
    } catch (ClassNotFoundException e1) {
      // TODO Auto-generated catch block
      e1.printStackTrace();
    }finally{
      try{
        while(!processes.isEmpty()){
          try {
            processes.remove(0).join();
          } catch (InterruptedException e) {
          }
        }
        rs.close();
        shut.close();
        prepStmt.close();
        connect.close();
      }catch(SQLException ignore){
      }
    }
  }
}
