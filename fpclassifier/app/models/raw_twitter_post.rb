class RawTwitterPost < ActiveRecord::Base
  attr_accessible :process_date, :processed, :rawdata
end
