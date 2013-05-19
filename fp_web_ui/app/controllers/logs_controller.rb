class LogsController < ApplicationController
  def error
    @data = File.read("public/log/error.log")
  end

  def debug
    @data = File.read("public/log/debug.log")
  end

  def info
    @data = File.read("public/log/info.log")
  end
end
