class RawTwitterPostsController < ApplicationController
  # GET /raw_twitter_posts
  # GET /raw_twitter_posts.json
  def index
    @raw_twitter_posts = RawTwitterPost.all

    respond_to do |format|
      format.html # index.html.erb
      format.json { render json: @raw_twitter_posts }
    end
  end

  # GET /raw_twitter_posts/1
  # GET /raw_twitter_posts/1.json
  def show
    @raw_twitter_post = RawTwitterPost.find(params[:id])

    respond_to do |format|
      format.html # show.html.erb
      format.json { render json: @raw_twitter_post }
    end
  end

  # GET /raw_twitter_posts/new
  # GET /raw_twitter_posts/new.json
  def new
    @raw_twitter_post = RawTwitterPost.new

    respond_to do |format|
      format.html # new.html.erb
      format.json { render json: @raw_twitter_post }
    end
  end

  # GET /raw_twitter_posts/1/edit
  def edit
    @raw_twitter_post = RawTwitterPost.find(params[:id])
  end

  # POST /raw_twitter_posts
  # POST /raw_twitter_posts.json
  def create
    @raw_twitter_post = RawTwitterPost.new(params[:raw_twitter_post])

    respond_to do |format|
      if @raw_twitter_post.save
        format.html { redirect_to @raw_twitter_post, notice: 'Raw twitter post was successfully created.' }
        format.json { render json: @raw_twitter_post, status: :created, location: @raw_twitter_post }
      else
        format.html { render action: "new" }
        format.json { render json: @raw_twitter_post.errors, status: :unprocessable_entity }
      end
    end
  end

  # PUT /raw_twitter_posts/1
  # PUT /raw_twitter_posts/1.json
  def update
    @raw_twitter_post = RawTwitterPost.find(params[:id])

    respond_to do |format|
      if @raw_twitter_post.update_attributes(params[:raw_twitter_post])
        format.html { redirect_to @raw_twitter_post, notice: 'Raw twitter post was successfully updated.' }
        format.json { head :no_content }
      else
        format.html { render action: "edit" }
        format.json { render json: @raw_twitter_post.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /raw_twitter_posts/1
  # DELETE /raw_twitter_posts/1.json
  def destroy
    @raw_twitter_post = RawTwitterPost.find(params[:id])
    @raw_twitter_post.destroy

    respond_to do |format|
      format.html { redirect_to raw_twitter_posts_url }
      format.json { head :no_content }
    end
  end
end
