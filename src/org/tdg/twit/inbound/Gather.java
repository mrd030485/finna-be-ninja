package org.tdg.twit.inbound;

import org.apache.log4j.Logger;
import java.net.Authenticator;
import java.net.MalformedURLException;
import java.net.PasswordAuthentication;
import java.net.URL;
import java.sql.Connection;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * Imports for threading
 */
import java.lang.Thread;
import org.tdg.twit.db.*;

public class Gather extends Thread {
	ExecutorService pool = Executors.newFixedThreadPool(10);
	static Logger logger = Logger.getLogger(Gather.class);
	private Connection connect = null;

	public Gather(String user, String pass, Connection conn) {
		super("Gather Data Thread");
		this.username = user;
		this.password = pass;
		this.connect = conn;
		logger.debug("Setup Gather Thread");
		start();
	}

	/**
	 * @param args
	 */
	String username = null;;
	String password = null;
	DataStats dataStats = null;

	public void run() {
		logger.info("Starting Gather Data Thread");
		Authenticator.setDefault(new Authenticator() {
			protected PasswordAuthentication getPasswordAuthentication() {
				return new PasswordAuthentication(username, password
						.toCharArray());
			}
		});
		if (connect == null) {
			logger.error(Gather.class.getName()
					+ ": Database connection is closed");
		} else {
			dataStats = new DataStats(connect);
		}
		try {
			boolean pause = false;
      boolean first = true;
			
			URL twitter = new URL("https://stream.twitter.com/1.1/statuses/sample.json?language=en");
			BufferedReader in = new BufferedReader(new InputStreamReader(twitter.openStream()));
			String input = null;
			String[] data = new String[500];
			int i=0;	// counter 0-150 submit data once we reach 150 records
			while ((input = in.readLine()) != null) {
          if(dataStats.getDBRowCount()<=50000){
            pause = false;
            first=true;
            data[i]=input;
	  				i++;
		  			if(i==500){
			  			pool.submit(new EnqueueTwitterPosts(data, connect));
              i=0;
					  }
          }else{
            pause=true;
          }
          if(pause && first){
            first=false;
            System.out.println("Waiting for processing to chatch up");
          }
			}
			in.close();
		} catch (MalformedURLException e1) {
			logger.error(e1.getMessage());
		} catch (IOException e2) {
			logger.error(e2.getMessage());
		}

		logger.info("Exiting Gather Data Thread");
		logger.info("Stream from twitter has dried up");
	}
}
