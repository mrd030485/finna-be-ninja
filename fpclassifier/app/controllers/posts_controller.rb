class PostsController < ApplicationController
  before_filter :authenticate_user!
  # GET /posts
  # GET /posts.json
  def index
    authorize! :index, @user
    @posts = Post.find(:all, :order => "id desc", :limit => 5).reverse

    respond_to do |format|
      format.html # index.html.erb 
      format.json { redirect_to :action => "new"}
    end
  end

  # GET /posts/1
  # GET /posts/1.json
  def show
    @post = Post.find(params[:id])

    respond_to do |format|
      format.html # show.html.erb
      format.json { render json: @post }
    end
  end

  # GET /posts/new
  # GET /posts/new.json
  def new
    @post = Post.new

    respond_to do |format|
      format.html # new.html.erb
      format.json { render json: @post }
    end
  end

  # POST /posts/
  # POST /posts.json
  def create
    @post=nil
    @thought = params[:post][:thought]
    if params[:post].has_key?(:keyword)
      @post = Post.new
      @post.thought = @thought
      @post.keyword = params[:post][:keyword]
    else
      thoughtCopy = removeStopWords(@thought.downcase)
      array = thoughtCopy.split
      array = array.sort_by{|x| x.length}.reverse
      @confidence = getConfidenceLevels(array)
      @posKeywords = findSuggestedKeyword(@confidence)
    end
    respond_to do |format|
      if @post==nil
        format.html {render action: "confirm"}
      else
        if @post.save
          format.html { redirect_to @post, notice: 'Post was successfully created.' }
          format.json { render json: @post, status: :created, location: @post }
        else
          format.html { render action: "new" }
          format.json { render json: @post.errors, status: :unprocessable_entity }
        end
      end
    end
  end

  # PUT /posts/1
  # PUT /posts/1.json
  def update
    @post = Post.find(params[:id])

    respond_to do |format|
      if @post.update_attributes(params[:post])
        format.html { redirect_to @post, notice: 'Post was successfully updated.' }
        format.json { head :no_content }
      else
        format.html { render action: "edit" }
        format.json { render json: @post.errors, status: :unprocessable_entity }
      end
    end
  end

  def removeStopWords(incoming)
    stopWords = ["my","you","me","but","your","and","i", "a", "an","are","as","at","be","by","com","for","from","how","in", "is","it","of","on","or","that","the","this","to","was","what","when","where","who","will","with"]
    
    outgoing = incoming.split.delete_if{|x| stopWords.include?(x.downcase)}.join(' ')

    return outgoing
  end

  def findSuggestedKeyword(array)
    ret=Hash.new
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
