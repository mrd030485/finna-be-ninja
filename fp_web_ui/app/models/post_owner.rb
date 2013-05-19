class PostOwner < ActiveRecord::Base
  belongs_to :recovered_status
  attr_accessible :user_id,:posted
end
