package org.tdg.twit.main;

import org.apache.log4j.*;
import org.apache.log4j.xml.DOMConfigurator;
import org.tdg.twit.analyze.ManageFPAnalysis;
import org.tdg.twit.inbound.*;
import org.tdg.twit.processing.ManagePostProcessing;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class FpClassifier {

	/**
	 * @param args
	 */
  
  public static final String DRIVER = "com.mysql.jdbc.Driver";
  public static final String URL = "jdbc:mysql://192.168.1.87:3306/fpclassifier_production";
  public static final String USERNAME = "fpclass";
  public static final String PASSWORD = null;

	static Logger logger = Logger.getLogger(FpClassifier.class);
	static ExecutorService pool = Executors.newFixedThreadPool(3);
	private static String statsQuery1 = "SELECT IFNULL( count( rp.status ) / count( raw.rawdata ) , 0 ) AS percentRecovered "
			+ "FROM recovered_statuses rp, raw_twitter_posts raw WHERE true";

	public static void main(String[] args) {
    Connection localConn = null;
    float stat1 = (float)0.0;
		boolean shutdown = false;
		boolean dl = true;
    ResultSet stats = null;
    ResultSet shut = null;
    ResultSet rs = null;

		DOMConfigurator.configure(FpClassifier.class.getClassLoader().getResource("log4j.xml"));
		logger.info("Starting app");

		String user = null;
		String password = null;
		
		if (args.length != 2) {

			System.err.println("Wrong arguments supplied: Example -- java -jar fpclassifier user password");
			logger.error(FpClassifier.class.getName()	+ ": Wrong arguments supplied: Example -- java -jar fpclassifier user password");
			System.exit(1);

		} else {

			user = args[0];
			password = args[1];

		}

		try {
		  Class.forName(DRIVER).newInstance();
		  localConn = DriverManager.getConnection(URL, USERNAME, PASSWORD); 

			shut = localConn.prepareStatement("select status from settings where name='shutdown'").executeQuery();
			rs = localConn.prepareStatement("select status from settings where name='download_statuses'").executeQuery();

			if (rs.next() && shut.next()) {
				if(shut.getInt(1) == 0){
          shutdown=false;
        }
        if(rs.getInt(1) == 1){
          dl=true;
        }
			} else {
				shutdown = false;
				dl = true;
			}
      
      shut.close();
			rs.close();
			
      pool.submit(new Gather(user, password));
        logger.debug("Submitted Gather to thread pool");
			pool.submit(new ManagePostProcessing());
        logger.debug("Submitted ManageProcess to thread pool");
      pool.submit(new ManageFPAnalysis());
        logger.debug("Started processing for fp-growth");

			while (!shutdown) {
			
        shut = localConn.prepareStatement("select status from settings where name='shutdown'").executeQuery();
				rs = localConn.prepareStatement("select status from settings where name='download_statuses'").executeQuery();

        if (rs.next() && shut.next()) {
				 if(shut.getInt(1) == 0){
           shutdown=false;
         }else{
           shutdown=true;
         }
				 if(rs.getInt(1) == 1){
           dl=true;
         }else{
          dl=false;
         }
				} else {
					shutdown = false;
					dl = true;
				}
				
        if (shutdown) {
					logger.info("System is shutting down");
				}
				if (!dl) {
					logger.info("No posts will be downloaded from twitter");
				}
				
        stats = localConn.prepareStatement(statsQuery1).executeQuery();

				if (stats.first()) {
          float statC = stats.getFloat(1);
          if(stat1!=statC){
  					stat1 = statC;
            logger.info("\t Percentage of usable posts: "+ statC);
  					logger.info(FpClassifier.class.getName() + ": Statistics");
          }
          /*
					 * logger.info("\t Percentage of posts downloaded w/Keyword: "
					 * + stats.getFloat(3));
					 * logger.info("\t Percentage of posts from users w/Keyword: "
					 * + stats.getFloat(2)); logger.info(
					 * "\t if the last number is not 1 then there is an issue with the systems post submissions"
					 * );
					 */
				}
        stats.close();
			}
      System.err.println("I am here now");
		} catch (SQLException e) {
			logger.error(FpClassifier.class.getName()+": "+e.getMessage());
      System.err.println("SQLE");
		} catch (Exception e) {
			logger.error(FpClassifier.class.getName()+": "+e.getMessage());
      System.err.println("EXCE");
		} finally {
			try {
				pool.shutdown();
				pool.awaitTermination(5, TimeUnit.MINUTES);
			} catch (InterruptedException e) {
				logger.error(e.getMessage());
			} finally {
				try {
          rs.close();
          shut.close();
				  stats.close();
          localConn.close();
        } catch (SQLException ignore) {
					// This is ok with me.
				} catch (NullPointerException ignore){
          System.err.println("Iam Exiting");
        }
			}

		}
	}
}
