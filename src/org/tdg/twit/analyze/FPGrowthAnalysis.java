package org.tdg.twit.analyze;

import java.io.IOException;

import org.apache.log4j.Logger;

import ca.pfv.spmf.frequentpatterns.fpgrowth_with_strings_saveToFile.AlgoFPGrowth;

public class FPGrowthAnalysis implements Runnable{
  Logger logger = Logger.getLogger(FPGrowthAnalysis.class);
  private AlgoFPGrowth fpGrowth = null;
  private StringBuffer output = new StringBuffer();
  private Double minSupport = 0.03;
  public FPGrowthAnalysis(){
    fpGrowth = new AlgoFPGrowth();
  }
  
  public void run(){
    
    GenerateFPInput gen = new GenerateFPInput();
    
    gen.run();
    
    StringBuffer input = gen.getInput();
    try {
      fpGrowth.runAlgorithm(input, minSupport);
      output = fpGrowth.getOutput();
      ProcessFPResults storeResults = new ProcessFPResults(output);
      storeResults.run();
    } catch (IOException e) {
      e.printStackTrace();
    }
    
  }
}
