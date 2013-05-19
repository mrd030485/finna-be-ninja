class TwitterAccountsController < ApplicationController

  before_filter :check_logged_in

  def check_logged_in
    if signed_in?
    else
      redirect_to new_user_session_path 
    end
  end

  def callback
    @omniauth = request.env["omniauth.auth"]
    t = TwitterAccount.new
    t.user_id=current_user.id
    t.oauth_token=@omniauth[:credentials][:token]
    t.oauth_token_secret=@omniauth[:credentials][:secret]
    t.active=true
    t.name=@omniauth[:info][:name]
    t.nickname=@omniauth[:info][:nickname]
    t.save
    flash[:notice]="Twitter integration is complete!"
  end

  def profile
  end

  def post_to_twitter
    cuta = TwitterAccount.find_by_user_id(current_user.id)
    user = Twitter::Client.new(
      :oauth_token => cuta.oauth_token,
      :oauth_token_secret => cuta.oauth_token_secret
    )

    user.update(params[:status])
  end

  def update
    name=params[:name]
    nick=params[:nickname]
    email=params[:email]
    disabled=params[:disable]
    twit=TwitterAccount.find_by_user_id(current_user.id)
    if disabled!=nil
      twit.active=false
    else
      twit.active=true
    end
    if !twit.name.eql?name
      twit.name=name
    end
    if !twit.nickname.eql?nick
      twit.nickname=nick
    end
    if twit.save
      flash[:notice]="Profile Update Success!"
    else
      flash[:error]="Profile Update Failed!"
    end
  end
end
