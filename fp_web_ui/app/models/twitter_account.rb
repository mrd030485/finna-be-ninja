class TwitterAccount < ActiveRecord::Base
  attr_accessible :active, :nickname, :oauth_token, :oauth_token_secret, :oauth_token_verifier, :name, :user_id
end
