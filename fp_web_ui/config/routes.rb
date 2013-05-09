FpWebUi::Application.routes.draw do
  resources :recovered_statuses, :path => :posts
  
  get "home/index"

  devise_for :users
  root :to => "home#index"
  match "/users/profile" => "users/profile#index", :as => :user_profile  
  match "/auth/twitter/callback" => "twitter_accounts#callback", :as => :twitter_callback
  match "/twitter/submit" => "twitter_accounts#submit", :as => :twitter_submit

end
