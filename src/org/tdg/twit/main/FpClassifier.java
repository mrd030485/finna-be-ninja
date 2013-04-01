package org.tdg.twit.main;

import org.apache.log4j.*;
import org.tdg.twit.db.ManageProcess;
import org.tdg.twit.inbound.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
public class FpClassifier {

	/**
	 * @param args
	 */
	
	static Logger logger = Logger.getLogger(FpClassifier.class);
  public static void main(String[] args) {
		PropertyConfigurator.configure(FpClassifier.class.getClassLoader().getResource("log4j.properties"));
		logger.info("Starting app");
		String user=null;
		String password=null;
    String url = "jdbc:mysql://192.168.1.87:3306/fpclassifier_development";
		if(args.length!=2){
			System.err.println("Wrong arguments supplied: Example -- java -jar fpclassifier user password");
			logger.error("Wrong arguments supplied: Example -- java -jar fpclassifier user password");
			System.exit(1);
		}else{
			user=args[0];
			password=args[1];
		}
    try{
      Class.forName("com.mysql.jdbc.Driver");
      new Gather(user,password,DriverManager.getConnection(url,"fpclass",null));
	    new ManageProcess(DriverManager.getConnection(url,"fpclass",null));
    }catch(SQLException e){
      logger.error(e.getMessage());
    }catch(ClassNotFoundException e){
      logger.error(e.getMessage());
    }
	}
}
