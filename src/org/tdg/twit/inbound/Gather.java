package org.tdg.twit.inbound;

import org.apache.log4j.Logger;
import java.net.Authenticator;
import java.net.MalformedURLException;
import java.net.PasswordAuthentication;
import java.net.URL;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.sql.DataSource;

import java.util.ArrayList;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

import org.tdg.twit.processing.*;

public class Gather implements Runnable {
  static  Logger          logger        = Logger.getLogger(Gather.class);
  private Connection      dataConnect   = null;
  private Connection      localConnect  = null;
  private QueueCount       dataStats     = null;
  private BufferedReader  in            = null;
  private ResultSet       shut          = null;
  private ResultSet       dl            = null;
  private String          username      = null;
  private String          password      = null;
  private int             runCount      = 200;
  
  public static final String DRIVER = "com.mysql.jdbc.Driver";
  public static final String URLDB = "jdbc:mysql://localhost:3306/fpclassifier_production";
  public static final String USERNAMEDB = "fpclass";
  public static final String PASSWORDDB = null;
  
  private ArrayList<Thread> processes   = null;
  
  public Gather(String user, String pass) {
    this.username = user;
    this.password = pass;
    processes = new ArrayList<>();
  }


  public void run() {
    logger.debug("Starting Gather Data Thread");
    Authenticator.setDefault(new Authenticator() {
      protected PasswordAuthentication getPasswordAuthentication() {
        return new PasswordAuthentication(username, password.toCharArray());
      }
    });
    try {
      Class.forName(DRIVER).newInstance();
      dataConnect = DriverManager.getConnection(URLDB, USERNAMEDB, PASSWORDDB);
      localConnect = DriverManager.getConnection(URLDB, USERNAMEDB, PASSWORDDB);
      dataStats = new QueueCount(dataConnect);
      logger.info(Gather.class.getName() + ": Downloading Statuses from twitter.");

      int overallCount = 0;
      int lastCount = -1;
      boolean pause = false;
      boolean first = true;
      shut = localConnect.prepareStatement("select status from settings where name='shutdown'").executeQuery();
      dl = localConnect.prepareStatement("select status from settings where name='download_statuses'").executeQuery();

      shut.first();
      
      String input = null;
      String[] data = new String[runCount];
      
      int i = 0;
      
      while (shut.getInt(1) == 0) {
        dl.first();
      
        if (dl.getInt(1) == 1) {
          URL twitter = new URL("https://stream.twitter.com/1.1/statuses/sample.json?language=en");
          in = new BufferedReader(new InputStreamReader(twitter.openStream()));
        }

        logger.info(Gather.class.getName() + ": there have been " + overallCount + " posts downloaded");
        
        while ((input = in.readLine()) != null) {
          if ((dl.getInt(1) == 1) && (shut.getInt(1) == 0)) {
            if (dataStats.getDBRowCount() <= 5000) {
              pause = false;
              first = true;
              data[i] = input;
              i++;
              if (i == runCount) {
                processes.add(new EnqueuePosts(data));
                i = 0;
                overallCount += runCount;
                data = new String[runCount];
              }
            } else {
              pause = true;
            }
            if (pause && first) {
              first = false;
              logger.debug("Waiting for processing to chatch up");
            }
          } else {
            break;
          }
          if(processes.size()>2){
            while(!processes.isEmpty()){
              try {
                processes.remove(0).join();
              } catch (InterruptedException e) {
              }
            }
          }
          if(lastCount<overallCount){
            logger.info(Gather.class.getName() + ": there have been " + overallCount + " posts downloaded");
            lastCount=overallCount;
          }
        }
        in.close();
        shut.close();
        dl.close();
        shut = localConnect.prepareStatement("select status from settings where name='shutdown'").executeQuery();
        dl = localConnect.prepareStatement("select status from settings where name='download_statuses'").executeQuery();
        while(!processes.isEmpty()){
          try {
            processes.remove(0).join();
          } catch (InterruptedException e) {
          }
        }
        shut.first();
      }
    } catch (MalformedURLException e1) {
      logger.error(Gather.class.getName() + ": " + e1.getMessage());
    } catch (IOException e2) {
      logger.error(Gather.class.getName() + ": " + e2.getMessage());
    } catch (SQLException e) {
      logger.error(Gather.class.getName() + ": " + e.getMessage());
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
        in.close();
        shut.close();
        dl.close();
        dataStats.close();
        localConnect.close();
        while(!processes.isEmpty()){
          try {
            processes.remove(0).join();
          } catch (InterruptedException e) {
          }
        }
      }catch(SQLException ignore){
      }catch(IOException ignore){
      }
    }

    logger.debug("Exiting Gather Data Thread");
  }
}
