package org.tdg.twit.main;

import org.apache.log4j.*;
import org.tdg.twit.db.ManageProcess;
import org.tdg.twit.inbound.*;

public class FpClassifier {

	/**
	 * @param args
	 */
	
	static Logger logger = Logger.getLogger(FpClassifier.class);
	
	public static void main(String[] args) {
		PropertyConfigurator.configure("resources/log4j.properties");
		logger.info("Starting app");
	    String user="mrdaze2";
	    String password="IwmtwomDi08m!";
	   // new Gather(user,password);
	    new ManageProcess();
	    System.out.println("Main Thread exiting");
	}

}
