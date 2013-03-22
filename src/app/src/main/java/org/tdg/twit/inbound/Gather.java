package org.tdg.twit.inbound;

import org.apache.log4j.Logger;
import org.apache.log4j.PropertyConfigurator;
import org.apache.log4j.FileAppender;
import org.apache.log4j.ConsoleAppender;

import java.net.Autenticator;
import java.net.PasswordAuthentication;

/**
 * Imports for threading
 */
import java.lang.Thread;

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
        protected PasswordAuthenticaton getPasswordAuthentication(){
            return new PasswordAuthentication(username,password.toCharArray());
        }
    });
    logger.info("Exiting Gather Data Thread");
    Thread.sleep(5000);
    System.out.println("Gather Data Thread Exiting");    
  }
}

