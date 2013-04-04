package org.tdg.twit.inbound;

import org.apache.log4j.Logger;
import java.net.Authenticator;
import java.net.MalformedURLException;
import java.net.PasswordAuthentication;
import java.net.URL;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
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
		logger.debug("Starting Gather Data Thread");
		Authenticator.setDefault(new Authenticator() {
			protected PasswordAuthentication getPasswordAuthentication() {
				return new PasswordAuthentication(username, password.toCharArray());
			}
		});
		if (connect == null) {
			logger.error(Gather.class.getName()
					+ ": Database connection is closed");
		} else {
			dataStats = new DataStats(connect);
		}
		try {
			logger.info(Gather.class.getName()+": Downloading Statuses from twitter.");
			int overallCount=0;
			boolean pause = false;
			boolean first = true;
			BufferedReader in = null;
			ResultSet shut = connect.prepareStatement("select status from settings where name='shutdown'").executeQuery();
			ResultSet dl = connect.prepareStatement("select status from settings where name='download_statuses'").executeQuery();
			shut.first();
			while (shut.getInt(1)==0) {
				dl.first();
				if (dl.getInt(1)==1) {
					URL twitter = new URL("https://stream.twitter.com/1.1/statuses/sample.json?language=en");
					in = new BufferedReader(new InputStreamReader(twitter.openStream()));
				}
				String input = null;
				String[] data = new String[500];
				int i = 0;
				while ((input = in.readLine()) != null) {
					if ((dl.getInt(1)==1) && (shut.getInt(1)==0)){
						if (dataStats.getDBRowCount() <= 50000) {
							pause = false;
							first = true;
							data[i] = input;
							i++;
							if (i == 500) {
								pool.submit(new EnqueueTwitterPosts(data,connect));
								i = 0;
								overallCount+=500;
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
					if((overallCount%400)==0){
						logger.info(Gather.class.getName()+": there have been "+overallCount+" posts downloaded");
					}
				}
				in.close();
				shut.close();
				dl.close();
				shut = connect.prepareStatement("select status from settings where name='shutdown'").executeQuery();
				dl = connect.prepareStatement("select status from settings where name='download_statuses'").executeQuery();
				shut.first();
			}
		} catch (MalformedURLException e1) {
			logger.error(Gather.class.getName()+": "+e1.getMessage());
		} catch (IOException e2) {
			logger.error(Gather.class.getName()+": "+e2.getMessage());
		} catch (SQLException e) {
			logger.error(Gather.class.getName()+": "+e.getMessage());
		}

		logger.debug("Exiting Gather Data Thread");
	}
}
