package org.tdg.twit.inbound;

import org.apache.log4j.Logger;
import org.apache.log4j.PropertyConfigurator;
import org.apache.log4j.FileAppender;
import org.apache.log4j.ConsoleAppender;
import java.net.Authenticator;
import java.net.MalformedURLException;
import java.net.PasswordAuthentication;
import java.net.URL;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * Imports for threading
 */
import java.lang.Thread;
import org.tdg.twit.db.*;

public class Gather extends Thread{
  static Logger logger = Logger.getLogger(Gather.class);
  public Gather(String user, String pass){
    super("Gather Data Thread");
    this.username=user;
    this.password=pass;
    logger.debug("Setup Gather Thread");
    start();
  }
  /**
   *  @param args
   */
  String username = null;;
  String password = null;
  public void run(){
    logger.info("Starting Gather Data Thread");
    Authenticator.setDefault(new Authenticator(){
    	protected PasswordAuthentication getPasswordAuthentication(){
            return new PasswordAuthentication(username,password.toCharArray());
        }
    });
    try {
    	int post_count=0;
		URL twitter = new URL("https://stream.twitter.com/1.1/statuses/sample.json");
		BufferedReader in = new BufferedReader(new InputStreamReader(twitter.openStream()));
		String input = null;
		while((input = in.readLine()) != null){
			System.out.println(new Integer(post_count).toString().toString()+": "+input);
			post_count++;
			
			new EnqueueTwitterPosts(input,null);
		}
	} catch (MalformedURLException e1) {
		logger.error(e1.getMessage());
	} catch (IOException e2){
		logger.error(e2.getMessage());
	}
    
    logger.info("Exiting Gather Data Thread");
    logger.info("Stream from twitter has dried up");    
  }
}

