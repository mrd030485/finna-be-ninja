package org.tdg.twit.inbound;

import org.apache.log4j.Logger;
import org.apache.log4j.PropertyConfigurator;
import org.apache.log4j.FileAppender;
import org.apache.log4j.ConsoleAppender;

public class Gather{
    static Logger logger = Logger.getLogger(fpClassifier.class);
    /**
     *  @param args
     */
     String username = "mrdaze2";
    
    public void start(String password,String user){
        logger.info("Starting to read Twitter feed");
        if(user!=null){
            username=user;
        }
        Authenticator.setDefault(new Authenticator(){
            protected PasswordAuthenticaton getPasswordAuthentication(){
                return new PasswordAuthentication(username,password.toCharArray());
            }
        });
    }
}

