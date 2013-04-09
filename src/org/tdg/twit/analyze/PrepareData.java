package org.tdg.twit.analyze;

import java.sql.Connection;
import java.sql.SQLException;
import java.util.ArrayList;

import org.apache.log4j.Logger;

public class PrepareData {

  Logger             logger        = Logger.getLogger(PrepareData.class);
  ArrayList<String> stopWords= new ArrayList<>();
  public PrepareData() {
	  String[] add = {"i", "a", "an","are","as","at","be","by","com","for","from","how","in", "is","it",
	          "of","on","or","that","the","this","to","was","what","when","where","who","will","with"};
	  for(int i=0; i<add.length; i++){
		  stopWords.add(add[i]);
	  }
  }

  public String dataForFPG(String in) {
	String out = "";
	String[] tokens;
	tokens = in.split(" ");
	for(int i=0; i<tokens.length; i++){
	  if(!stopWords.contains(tokens[i])){
	    out = out + " " + tokens[i];
	  }
	}
	out = out.trim(); //Remove leading whitespace if any exists.
    return out;
  }

}
