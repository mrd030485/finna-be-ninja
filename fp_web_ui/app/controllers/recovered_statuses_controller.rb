class RecoveredStatusesController < ApplicationController
  before_filter :check_logged_in

  def check_logged_in
    if signed_in?
    else
      redirect_to new_user_session_path 
    end
  end

  def index
    @recovered_statuses = RecoveredStatus.find(:all, :conditions => {:id=>PostOwner.find_all_by_user_id(current_user.id).map{|c| c.recoverd_status_id}})
  end

  def new
    @recovered_status = RecoveredStatus.new
  end

  # POST /recovered_statuses
  # POST /recovered_statuses.json
  def create
    @recovered_status = nil
    @params = params[:recovered_status]
      status = removeStopWords(@params[:status].downcase)
      array = status.split
      array = array.sort_by{|x| x.length}.reverse
      @confidence = getConfidenceLevels(array)
      @freq = findSuggestedKeyword(@confidence)
      @params[:status]=@params[:status].downcase
      @recovered_status = RecoveredStatus.new(@params)
      @recovered_status.processed=true
      respond_to do |format|
        if @recovered_status.save
          @own = PostOwner.new
          @own.user_id=current_user.id
          @own.recoverd_status_id=@recovered_status.id
          @own.save
          format.html { render action: "update" }
          format.mobile { render action: "update"}
        else
          format.html { render action: "new" }
          format.mobile { render action: "new" }
        end
      end
  end

  def update
    @record =  RecoveredStatus.find(params[:recovered_status][:id])
    @record.processed=false
    @record.keywords = params[:recovered_status][:keywords]
    @record.save
    @recovered_statuses = RecoveredStatus.find(:all, :conditions => {:id=>PostOwner.find_all_by_user_id(current_user.id).map{|c| c.recoverd_status_id}})
    render action: "index"
  end

  def removeStopWords(incoming)
    stopWords = ["my","you","me","but","your","and","i", "a", "an","are","as","at","be","by","com","for","from","how","in", "is","it","of","on","or","that","the","this","to","was","what","when","where","who","will","with"]
    
    outgoing = incoming.split.delete_if{|x| stopWords.include?(x.downcase)}.join(' ')

    return outgoing
  end

  def findSuggestedKeyword(array)
    ret=Hash.new
    ret["none"] = 0
    array.each do |post|
      beg_pat = post.pattern.split[0]
      @processPost = RecoveredStatus.where("status like :firstWord", {:firstWord=>"%#{beg_pat}%"})
      @processPost.each do |recovered|
        if recovered.keywords.length>0
          if recovered.keywords.include?("<endofhashtag/>")
            recovered.keywords.split("<endofhashtag/>").each do |keyword|
              if ret.has_key?(keyword)
                ret[keyword] = ret[keyword]+1
              else
                ret[keyword]=1
              end
            end
          end
        end
      end
    end
    ret = ret.sort_by{|_key,value| value}.reverse
    ret.each do |alter|
      alter[1]=alter[0]
    end
    return ret
  end
  def getConfidenceLevels(array)
    @allFrequent = Frequent.order("confidence desc, length(pattern) desc")
    parse = Array.new
    @allFrequent.each do |check|
      array.each do |value|
        if check.pattern.include?(value)
          parse.push(check)
        end
      end
    end
    parse = parse.uniq
    p1 = Array.new
    p2 = Array.new
    parse.each do |copy|
      p1.push(copy)
    end
    p1.each do |main|
      p1.each do |sub|
        all=sub.pattern.split.uniq.length
        sub.pattern.split.uniq.each do |test|
          if main.pattern.include?(test)
            all=all-1
          end
        end
        if all==0
          p1.delete(sub)
          p2.push(main)
        end
      end
    end
    
    parse = p2.uniq
    
    return parse

  end
end
