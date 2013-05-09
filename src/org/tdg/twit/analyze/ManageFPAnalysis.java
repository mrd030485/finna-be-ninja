package org.tdg.twit.analyze;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import org.apache.log4j.Logger;

public class ManageFPAnalysis implements Runnable {
  private Connection        connect    = null;
  private ResultSet         contRs     = null;
  private ResultSet         countRs    = null;
  private PreparedStatement stmtCount  = null;
  private PreparedStatement stmtCont  = null;
  public static final String DRIVER      = "com.mysql.jdbc.Driver";
  public static final String URLDB       = "jdbc:mysql://192.168.1.87:3306/fpclassifier_production";
  public static final String USERNAMEDB  = "fpclass";
  public static final String PASSWORDDB  = null;

  Logger                    logger     = Logger.getLogger(ManageFPAnalysis.class);
  private String            shutQuery  = "select status from settings where name = 'shutdown'";
  private String            countQuery = "select count(*) from recovered_statuses where processed=0";

  public ManageFPAnalysis() {
  }

  public void run() {
    try {
      Class.forName(DRIVER).newInstance();
      connect = DriverManager.getConnection(URLDB, USERNAMEDB, PASSWORDDB);
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
          if(countRs.getInt(1)>500){
            FPGrowthAnalysis FpG = new FPGrowthAnalysis();
            FpG.run();
          }
        }

        contRs = stmtCont.executeQuery();
        if (!contRs.first()) {
          throw new Exception("Unable to query database settings");
        }
      }
    } catch (SQLException e) {
      logger.error(ManageFPAnalysis.class.getName() + ": " + e.getMessage());
    } catch (Exception e) {
      logger.error(ManageFPAnalysis.class.getName() + ": " + e.getMessage());
    }
  }

}
