package org.tdg.twit.analyze;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;

import javax.sql.DataSource;

import org.apache.log4j.Logger;

public class GenerateFPGData implements Runnable {

  Logger             logger   = Logger.getLogger(GenerateFPGData.class);
  private DataSource ds       = null;
  private Connection connect  = null;
  private ResultSet  contRs = null;
  private String shutQuery = "select status from settings where name = 'shutdown'";
  public GenerateFPGData(DataSource ds) {
    this.ds = ds;
  }

  public void run() {

    try {
      connect = ds.getConnection();
      contRs = connect.prepareStatement(shutQuery).executeQuery();
      if(!contRs.first()){
        throw new Exception("Unable to query database settings");
      }
      while(contRs.getInt(1)!=1){
        
        contRs.close();
        contRs = connect.prepareStatement(shutQuery).executeQuery();
        if(!contRs.first()){
          throw new Exception("Unable to query database settings");
        }
        
      }
    } catch (SQLException e) {

    } catch(Exception e){
      logger.debug(GenerateFPGData.class.getName()+": "+e.getMessage());
    }finally {
      try {
        contRs.close();
        connect.close();
      } catch (SQLException ignore) {
      }
    }

  }

}
