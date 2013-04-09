package org.tdg.twit.analyze;

import java.sql.Connection;
import java.sql.SQLException;

import org.apache.log4j.Logger;

public class PrepareData {

  Logger             logger        = Logger.getLogger(PrepareData.class);

  private Connection connect       = null;

  private String     selectRecords = "select * from recovered_statuses where keywords!='-'";

  public PrepareData(Connection conn) {
    this.connect = conn;
  }

  public String dataForFPG() {
    try {
      connect.prepareStatement(selectRecords);
    } catch (SQLException e) {
      logger.error(PrepareData.class.getName() + ": " + e.getMessage());
    } finally {
      try {
        connect.close();
      } catch (SQLException ignore) {
      }
    }
    return "";
  }

}
