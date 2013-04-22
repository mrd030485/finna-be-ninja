package org.tdg.twit.inbound;

import org.apache.log4j.Logger;
import java.net.Authenticator;
import java.net.MalformedURLException;
import java.net.PasswordAuthentication;
import java.net.URL;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.sql.DataSource;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import org.tdg.twit.db.*;

public class Gather implements Runnable {
  ExecutorService         pool          = Executors.newFixedThreadPool(10);
  static  Logger          logger        = Logger.getLogger(Gather.class);
  private DataSource      ds            = null;
  private Connection      dataConnect   = null;
  private Connection      localConnect  = null;
  private DataStats       dataStats     = null;
  private BufferedReader  in            = null;
  private ResultSet       shut          = null;
  private ResultSet       dl            = null;
  private String          username      = null;
  private String          password      = null;
  private int             runCount      = 200;
  public Gather(String user, String pass, DataSource ds) {
    this.username = user;
    this.password = pass;
    this.ds = ds;
  }


  public void run() {
    logger.debug("Starting Gather Data Thread");
    Authenticator.setDefault(new Authenticator() {
      protected PasswordAuthentication getPasswordAuthentication() {
        return new PasswordAuthentication(username, password.toCharArray());
      }
    });
    if (ds == null) {
      logger.error(Gather.class.getName() + ": Database connection is closed");
    }
    try {
      dataConnect = ds.getConnection();
      localConnect = ds.getConnection();
      dataStats = new DataStats(dataConnect);
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
                pool.execute(new EnqueueTwitterPosts(data, ds.getConnection()));
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

        shut.first();
      }
    } catch (MalformedURLException e1) {
      logger.error(Gather.class.getName() + ": " + e1.getMessage());
    } catch (IOException e2) {
      logger.error(Gather.class.getName() + ": " + e2.getMessage());
    } catch (SQLException e) {
      logger.error(Gather.class.getName() + ": " + e.getMessage());
    }finally{
      try{
        in.close();
        shut.close();
        dl.close();
        dataStats.close();
        localConnect.close();
      }catch(SQLException ignore){
      }catch(IOException ignore){
      }
    }

    logger.debug("Exiting Gather Data Thread");
  }
}
