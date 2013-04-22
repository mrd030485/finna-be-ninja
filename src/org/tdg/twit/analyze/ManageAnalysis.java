package org.tdg.twit.analyze;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import javax.sql.DataSource;

import org.apache.log4j.Logger;

public class ManageAnalysis implements Runnable {
  private DataSource        ds         = null;
  private Connection        connect    = null;
  private ResultSet         contRs     = null;
  private ResultSet         countRs    = null;
  private PreparedStatement stmtCount  = null;
  private PreparedStatement stmtCont  = null;

  Logger                    logger     = Logger.getLogger(ManageAnalysis.class);
  private String            shutQuery  = "select status from settings where name = 'shutdown'";
  private String            countQuery = "select count(*) from recovered_statuses where processed=0";

  public ManageAnalysis(DataSource ds) {
    this.ds = ds;
  }

  public void run() {
    try {
      connect = ds.getConnection();
      stmtCont = connect.prepareStatement(shutQuery);
      stmtCount = connect.prepareStatement(countQuery);
      contRs = stmtCont.executeQuery();
      if (!contRs.first()) {
        throw new Exception("Unable to query database settings");
      }
      while (contRs.getInt(1) != 1) {
        contRs.close();

        countRs = stmtCount.executeQuery();
        if(countRs.first()){
          if(countRs.getInt(1)>10000){
            Runnable r = new GenerateStatusFile(ds);
            r.run();
            Runnable t = new ImportFPStatuses(ds);
            t.run();
          }
        }

        contRs = stmtCont.executeQuery();
        if (!contRs.first()) {
          throw new Exception("Unable to query database settings");
        }
      }
    } catch (SQLException e) {
      logger.error(ManageAnalysis.class.getName() + ": " + e.getMessage());
    } catch (Exception e) {
      logger.error(ManageAnalysis.class.getName() + ": " + e.getMessage());
    }
  }

}
