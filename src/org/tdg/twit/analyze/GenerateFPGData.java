package org.tdg.twit.analyze;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import javax.sql.DataSource;

import org.apache.log4j.Logger;

import com.mysql.jdbc.Statement;

public class GenerateFPGData implements Runnable {

  Logger             logger   = Logger.getLogger(GenerateFPGData.class);
  private DataSource ds       = null;
  private Connection connect  = null;
  private ResultSet  contRs = null;
  private ResultSet  data = null;
  private PreparedStatement  stmt = null;
  private String shutQuery = "select status from settings where name = 'shutdown'";
  private String dataQuery = "select * from recovered_posts where processed=0";
  private String setProcess = "update recovered_posts set processed=1 were id>=? AND id<=?";
  private String insert = "insert into frequent (post,keyword,confidence,created_at,updated_at) values ";
  private int startId = -1;
  private int endId = -1;
  boolean first = true;
  
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
          
      	FileWriter outFile = new FileWriter(new File("/home/dev/github/my-repos/finna-be-ninja/data/items.dat"));
    	BufferedWriter oFw = new BufferedWriter(outFile);
    	
    	
    	data = connect.prepareStatement(dataQuery).executeQuery();
    	PrepareData prep = new PrepareData();
    	while(data.next()){
    		oFw.write(prep.dataForFPG(data.getString("status"))+"\n");
    		if(first){
    			startId = data.getInt("id");
    			first = false;
    		}
    		endId = data.getInt("id");
    	}
    	oFw.close();
    	outFile.close();
    	
    	stmt = connect.prepareStatement(setProcess);
    	stmt.setInt(1, startId);
    	stmt.setInt(2, endId);
    	stmt.executeUpdate();
    	
    	Process process = Runtime.getRuntime().exec("/home/dev/github/my-repos/finna-be-ninja/lib/processData");
    	process.wait();
    	
    	File inFile = new File("/home/dev/github/my-repos/finna-be-ninja/data/sets.dat");
    	FileReader inF = new FileReader(inFile);
    	BufferedReader iFr = new BufferedReader(inF);
    	String line=null;
    	ArrayList<String> patterns = new ArrayList<>();
    	ArrayList<String> keywords = new ArrayList<>();
    	ArrayList<Double> confidence = new ArrayList<>();
    	boolean ands = false;
    	while((line = iFr.readLine())!=null){
    		String[] tokens = line.split(" ");
    		String findKeywords = "select keywords from recovered_statuses where ";
    		String patt="";
    		for(int j=0; j<tokens.length; j++){
    			if(tokens[j].contains("(")){
    				String conv =tokens[j].replace("(", "");
    				conv = conv.replace(")","");
    				confidence.add(Double.parseDouble(conv));
    			}else{
    				patt = patt+" "+tokens[j];
    			}
    			if(ands){
    				findKeywords=findKeywords+"AND (status like '"+tokens[j]+"%' OR status like '%"+tokens[j]+"%' OR status like '%"+tokens[j]+"')";
    			}else{
    				findKeywords=findKeywords+"(status like '"+tokens[j]+"%' OR status like '%"+tokens[j]+"%' OR status like '%"+tokens[j]+"')";
    				ands = true;
    			}
    		}
    		ResultSet rs = connect.prepareStatement(findKeywords).executeQuery();
    		if(rs.next()){
    			keywords.add(rs.getString(1));
    		}else{
    			keywords.add("-");
    		}
    		patt=patt.trim();
    		patterns.add(patt);
    	}
    	StringBuilder sb = new StringBuilder(insert);
      boolean firstIns = true;
    	while(!patterns.isEmpty()){
    		if(firstIns){
    			sb.append("('"+patterns.remove(0)+"','"+keywords.remove(0)+"','"+confidence.remove(0)+",NOW(),NOW()");
          firstIns = false;
    		}else{
    			sb.append(",('"+patterns.remove(0)+"','"+keywords.remove(0)+"','"+confidence.remove(0)+",NOW(),NOW()");
        }
    	}
      
      connect.prepareStatement(sb.toString()).executeUpdate();
  
    	iFr.close();
    	inF.close();
    	contRs = connect.prepareStatement(shutQuery).executeQuery();
        if(!contRs.first()){
          oFw.close();
          throw new Exception("Unable to query database settings");
        }
        
      }
    } catch (SQLException e) {
      logger.debug(GenerateFPGData.class.getName()+": "+e.getMessage());
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
