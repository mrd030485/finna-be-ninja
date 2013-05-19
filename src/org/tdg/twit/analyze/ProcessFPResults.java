package org.tdg.twit.analyze;

import java.io.BufferedReader;
import java.io.StringReader;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import org.apache.log4j.Logger;

public class ProcessFPResults implements Runnable {

  Logger                     logger         = Logger
                                                .getLogger(ProcessFPResults.class);
  private Connection         connect        = null;
  private ResultSet          contRs         = null;
  private String             shutQuery      = "select status from settings where name = 'shutdown'";
  private String             insert         = "insert into frequents (pattern,confidence,created_at,updated_at) values ";
  private String             onDuplicateKey = " ON DUPLICATE KEY UPDATE confidence = VALUES(confidence)";
  public static final String DRIVER         = "com.mysql.jdbc.Driver";
  public static final String URLDB          = "jdbc:mysql://localhost:3306/fpclassifier_production";
  public static final String USERNAMEDB     = "fpclass";
  public static final String PASSWORDDB     = null;

  private StringBuffer       input          = null;

  public ProcessFPResults(StringBuffer input) {
    this.input = input;
  }

  public void run() {

    try {
      Class.forName(DRIVER).newInstance();
      connect = DriverManager.getConnection(URLDB, USERNAMEDB, PASSWORDDB);
      contRs = connect.prepareStatement(shutQuery).executeQuery();
      if (!contRs.first()) {
        throw new Exception("Unable to query database settings");
      }
      if (contRs.getInt(1) != 1) {

        contRs.close();

        StringReader results = new StringReader(input.toString());
        BufferedReader resultsReader = new BufferedReader(results);
        String line = null;
        ArrayList<String> patterns = new ArrayList<>();
        ArrayList<Double> confidence = new ArrayList<>();
        while ((line = resultsReader.readLine()) != null) {
          String[] parts = line.split(":");
          confidence.add(Double.parseDouble(parts[1]));
          String patt = parts[0];
          patt = patt.trim();
          patterns.add(patt);
        }
        StringBuilder sb = new StringBuilder(insert);
        boolean firstIns = true;
        while (!patterns.isEmpty()) {
          if (firstIns) {
            sb.append("('" + patterns.remove(0) + "','" + confidence.remove(0)
                + "',NOW(),NOW())");
            firstIns = false;
          } else {
            sb.append(",('" + patterns.remove(0) + "','" + confidence.remove(0)
                + "',NOW(),NOW())");
          }
        }
        sb.append(onDuplicateKey);
        connect.prepareStatement(sb.toString()).executeUpdate();
        resultsReader.close();
        results.close();
      }
    } catch (SQLException e) {
      logger.error(ProcessFPResults.class.getName() + ": " + e.getMessage());
    } catch (Exception e) {
      logger.error(ProcessFPResults.class.getName() + ": " + e.getMessage());
    } finally {
      try {
        contRs.close();
        connect.close();
      } catch (SQLException ignore) {
      }
    }

  }

}
