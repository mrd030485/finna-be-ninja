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
		String user=null;
		String password=null;
		if(args.length!=2){
			System.err.println("Wrong arguments supplied must run FpClassifier user password");
			logger.error("Wrong arguments supplied must run FpClassifier user password");
			System.exit(1);
		}else{
			user=args[0];
			password=args[1];
		}
	    new Gather(user,password);
	    new ManageProcess();
	    System.out.println("Main Thread exiting");
	}

}
