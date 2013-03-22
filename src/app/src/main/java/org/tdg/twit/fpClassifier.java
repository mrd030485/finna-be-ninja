package org.tdg.twit;

import org.apache.log4j.Logger;
import org.apache.log4j.PropertyConfigurator;
import org.apache.log4j.ConsoleAppender;
import org.apache.log4j.FileAppender;
import org.tdg.twit.inbound.*;
public class fpClassifier {

	static Logger logger = Logger.getLogger(fpClassifier.class);
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		PropertyConfigurator.configure("resources/log4j.properties");
	  logger.info("Starting app");
    String user="mrdaze2";
    String password="IwmtwomDi08m!";
    new Gather(user,password);
    System.out.println("Main Thread exiting");
  }

}
