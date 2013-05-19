class AdminController < ApplicationController

  before_filter :check_logged_in

  def check_logged_in
    if signed_in? && User.find(current_user.id).admin
    else
      redirect_to new_user_session_path 
    end
  end
  
  def index
  if RawTwitterPosts.all[0]!=nil && RecoveredStatus.all[0]!=nil
   endTime = RawTwitterPosts.order("created_at asc limit 1")[0].created_at
   startTime = RawTwitterPosts.order("created_at desc limit 1")[0].created_at
   numHours = ((startTime - endTime)/1.hour).round
   @count = RawTwitterPosts.count()
   @rec = RecoveredStatus.count()
  else
    numHours=0
    @count=0
    @rec=0
  end
  if numHours > 0
     @rateRaw = @count/numHours
     @rateRecovered = @rec/numHours
   else
     @rateRaw = 0.0
     @rateRecovered = 0.0
   end
 

  end
  def online
    set = Setting.find_by_name('shutdown')
    set.status = !set.status
    set.save
    if !set.status
      pid = spawn("../start.sh #{Setting.find_by_name('user').data} #{Setting.find_by_name('password').data}",{:out=>"../stdout.log"})
      Process.detach(pid)
    end
    redirect_to :controller=>"admin", :action=>"index"
  end
  def download
    set = Setting.find_by_name('download_statuses')
    set.status = !set.status
    set.save
    redirect_to :controller=>"admin", :action=>"index"
  end
end
