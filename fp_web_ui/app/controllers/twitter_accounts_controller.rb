class TwitterAccountsController < ApplicationController
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

end
