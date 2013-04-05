class DebugController < ApplicationController
  def index
    @content = read_file(Rails.public_path+"/logs/debug.log")
  end
  def read_file(file_name)
    file = File.open(file_name, "r")
    data = file.read
    file.close
    return data
  end
end
