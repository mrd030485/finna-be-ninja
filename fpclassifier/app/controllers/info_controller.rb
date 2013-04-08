class InfoController < ApplicationController
  def index
    @content = read_file(Rails.public_path+"/logs/info.log")
  end
  def read_file(file_name)
    file = File.open(file_name, "r")
    data = file.read
    
    formattedFile="</ul>"

    data.gsub!(/\r\n?/,"\n")
    data.each_line do |line|
      formattedFile = "<li>"+line+"</li>"+formattedFile
    end
    formattedFile = "<ul>"+formattedFile
    
    file.close
    
    return formattedFile
  end
end
