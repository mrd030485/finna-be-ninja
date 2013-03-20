package org.tdg.twit;

import org.apache.log4j.Logger;
import org.apache.log4j.PropertyConfigurator;
import org.apache.log4j.ConsoleAppender;
import org.apache.log4j.FileAppender;
import org.tdg.twit.gui.*;
public class fpClassifier {

	static Logger logger = Logger.getLogger(fpClassifier.class);
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		PropertyConfigurator.configure("resources/log4j.properties");
		if(args.length>1){
			logger.debug("Error in arguments expected 0 or 1 got 2");
		}
		if(args.length!=0){
			if(args[1].equals("-c"))//run from console
			{
		    System.out.println("you have successfully started the app for command line use");
            System.exit(0);
			}
		}else{
			logger.debug("Open - Control Panel");
			controlPanel.ccPanel(null);
			logger.debug("Exit - Control Panel");
		}
	}

}
