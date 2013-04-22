package org.tdg.twit.analyze;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import javax.sql.DataSource;

import org.apache.log4j.Logger;

public class GenerateStatusFile implements Runnable {

  private DataSource        ds         = null;
  private Connection        connect    = null;
  private PreparedStatement stmtCont   = null;
  private PreparedStatement stmt       = null;
  private ResultSet         contRs     = null;
  private ResultSet         data       = null;

  Logger                    logger     = Logger
                                           .getLogger(GenerateStatusFile.class);
  private String            shutQuery  = "select status from settings where name = 'shutdown'";
  private String            dataQuery  = "select * from recovered_statuses where processed=0";
  private String            setProcess = "update recovered_statuses set processed=1 where id>=? AND id<=?";

  private int               startId    = -1;
  private int               endId      = -1;
  boolean                   first      = true;

  public GenerateStatusFile(DataSource ds) {
    this.ds = ds;
  }

  public void run() {
    try {
      connect = ds.getConnection();
      stmtCont = connect.prepareStatement(shutQuery);

      contRs = stmtCont.executeQuery();
      if (!contRs.first()) {
        throw new Exception("Unable to query database settings");
      }
      if(contRs.getInt(1) != 1) {
        contRs.close();

        FileWriter outFile = new FileWriter(new File(
            "/home/dev/github/my-repos/finna-be-ninja/data/items.dat"),true);
        BufferedWriter oFw = new BufferedWriter(outFile);

        data = connect.prepareStatement(dataQuery).executeQuery();
        PrepareData prep = new PrepareData();
        while (data.next()) {
          oFw.write(prep.dataForFPG(data.getString("status")) + "\n");
          if (first) {
            startId = data.getInt("id");
            first = false;
          }
          endId = data.getInt("id");
        }
        oFw.close();
        outFile.close();
        Process process = Runtime.getRuntime().exec("/home/dev/github/my-repos/finna-be-ninja/lib/processData");
        process.waitFor();
        stmt = connect.prepareStatement(setProcess);
        stmt.setInt(1, startId);
        stmt.setInt(2, endId);
        stmt.executeUpdate();
      }
    } catch (SQLException e) {
      logger.error(GenerateStatusFile.class.getName() + ": " + e.getMessage());
    } catch (Exception e) {
      logger.error(GenerateStatusFile.class.getName() + ": " + e.getMessage());
    }finally{
      try{
        stmt.close();
        connect.close();
      }catch(SQLException e){
      }
    }
  }

}
