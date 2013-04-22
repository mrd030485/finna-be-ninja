package org.tdg.twit.analyze;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import javax.sql.DataSource;

import org.apache.log4j.Logger;

public class ImportFPStatuses implements Runnable {

  Logger             logger        = Logger.getLogger(ImportFPStatuses.class);
  private DataSource ds            = null;
  private Connection connect       = null;
  private ResultSet  contRs        = null;
  private String     shutQuery     = "select status from settings where name = 'shutdown'";
  private String     insert        = "insert into frequents (pattern,confidence,created_at,updated_at) values ";
  private String     truncateTable = "truncate frequents";

  public ImportFPStatuses(DataSource ds) {
    this.ds = ds;
  }

  public void run() {

    try {
      connect = ds.getConnection();
      contRs = connect.prepareStatement(shutQuery).executeQuery();
      if (!contRs.first()) {
        throw new Exception("Unable to query database settings");
      }
      if (contRs.getInt(1) != 1) {

        contRs.close();
        
        File inFile = new File("/home/dev/github/my-repos/finna-be-ninja/data/sets.dat");
        FileReader inF = new FileReader(inFile);
        BufferedReader iFr = new BufferedReader(inF);
        String line = null;
        ArrayList<String> patterns = new ArrayList<>();
        ArrayList<Double> confidence = new ArrayList<>();
        while ((line = iFr.readLine()) != null) {
          String[] tokens = line.split(" ");
          String patt = "";
          for (int j = 0; j < tokens.length; j++) {
            if (tokens[j].contains("(")) {
              String conv = tokens[j].replace("(", "");
              conv = conv.replace(")", "");
              confidence.add(Double.parseDouble(conv));
            } else {
              patt = patt + " " + tokens[j];
            }
          }
          patt = patt.trim();
          patterns.add(patt);
        }
        StringBuilder sb = new StringBuilder(insert);
        boolean firstIns = true;
        while (!patterns.isEmpty()) {
          if (firstIns) {
            sb.append("('"+patterns.remove(0)+"','"+confidence.remove(0)+"',NOW(),NOW())");
            firstIns = false;
          } else {
            sb.append(",('"+patterns.remove(0)+"','"+confidence.remove(0)+"',NOW(),NOW())");
          }
        }

        connect.prepareStatement(sb.toString()).executeUpdate();
        connect.prepareStatement(truncateTable).executeUpdate();
        connect.prepareStatement(sb.toString()).executeUpdate();
        iFr.close();
        inF.close();
      }
    } catch (SQLException e) {
      logger.error(ImportFPStatuses.class.getName() + ": " + e.getMessage());
    } catch (Exception e) {
      logger.error(ImportFPStatuses.class.getName() + ": " + e.getMessage());
    } finally {
      try {
        contRs.close();
        connect.close();
      } catch (SQLException ignore) {
      }
    }

  }

}
