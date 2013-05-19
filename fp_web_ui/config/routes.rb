FpWebUi::Application.routes.draw do
  get "logs/error"

  get "logs/debug"

  get "logs/info"

  get "admin/index"

  resources :recovered_statuses, :path => :posts
  
  get "home/index"

  devise_for :users
  root :to => "home#index"
  match "/users/profile" => "twitter_accounts#profile", :as => :user_profile  
  match "/users/profile/update" => "twitter_accounts#update", :as => :user_profile_update  
  match "/auth/twitter/callback" => "twitter_accounts#callback", :as => :twitter_callback
  match "/twitter/submit" => "twitter_accounts#post_to_twitter", :as => :twitter_submit
  match "/admin/toggleOnline" => "admin#online", :as => :toggle_state
  match "/admin/toggleDownload" => "admin#download", :as => :toggle_dl
end
