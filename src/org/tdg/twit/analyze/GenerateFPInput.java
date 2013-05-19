package org.tdg.twit.analyze;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.StringReader;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Collections;
import org.apache.log4j.Logger;

public class GenerateFPInput {

  private Connection         connect    = null;
  private PreparedStatement  stmtCont   = null;
  private PreparedStatement  stmt       = null;
  private ResultSet          contRs     = null;
  private ResultSet          data       = null;
  
  private ArrayList<String>  stopWords  = null;
  
  public static final String DRIVER     = "com.mysql.jdbc.Driver";
  public static final String URLDB      = "jdbc:mysql://localhost:3306/fpclassifier_production";
  public static final String USERNAMEDB = "fpclass";
  public static final String PASSWORDDB = null;

  Logger                     logger     = Logger.getLogger(GenerateFPInput.class);
  
  
  private String             shutQuery  = "select status from settings where name = 'shutdown'";
  private String             dataQuery  = "select * from recovered_statuses where processed=0";
  private String             setProcess = "update recovered_statuses set processed=1 where id>=? AND id<=?";

  private int                startId    = -1;
  private int                endId      = -1;
  
  boolean                    first      = true;

  public GenerateFPInput() {
    String[] add = { "i", "a", "an", "are", "as", "at", "be", "by", "com",
        "for", "from", "how", "in", "is", "it", "of", "on", "or", "my", "you",
        "me", "but", "your", "and", "that", "the", "this", "to", "was", "what",
        "when", "where", "who", "will", "with" };
    stopWords = new ArrayList<>();
    Collections.addAll(stopWords, add);
    add = null;
  }

  private StringBuffer input = new StringBuffer();
  
  public void run() {
    try {
      Class.forName(DRIVER).newInstance();
      connect = DriverManager.getConnection(URLDB, USERNAMEDB, PASSWORDDB);
      stmtCont = connect.prepareStatement(shutQuery);
      contRs = stmtCont.executeQuery();
      if (!contRs.first()) {
        throw new Exception("Unable to query database settings");
      }
      if (contRs.getInt(1) != 1) {
        contRs.close();

        data = connect.prepareStatement(dataQuery).executeQuery();
        while (data.next()) {
          input.append(removeStopWords(data.getString("status")) + "\n");
          if (first) {
            startId = data.getInt("id");
            first = false;
          }
          endId = data.getInt("id");
        }
        stmt = connect.prepareStatement(setProcess);
        stmt.setInt(1, startId);
        stmt.setInt(2, endId);
        stmt.executeUpdate();
      }
    } catch (SQLException e) {
      logger.error(GenerateFPInput.class.getName() + ": " + e.getMessage());
    } catch (Exception e) {
      logger.error(GenerateFPInput.class.getName() + ": " + e.getMessage());
    } finally {
      try {
        stmt.close();
        connect.close();
      } catch (SQLException e) {
      }
    }
  }

  public StringBuffer getInput() {
    return input;
  }
  
  private String removeStopWords(String in) {
    String out = "";
    String[] tokens;
    tokens = in.split(" ");
    ArrayList<String> token = new ArrayList<>();
    Collections.addAll(token, tokens);
    Collections.sort(token, new StringLength());
    while (!token.isEmpty()){
      String temp = token.remove(0);
      if(!stopWords.contains(temp) && temp.length()>2){
        out = out + " " + temp;
      }
    }
    out = out.replaceAll("\n","");
    out = out.trim(); //Remove leading whitespace if any exists.
      return out;
    }
}
