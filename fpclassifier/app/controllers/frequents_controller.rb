class FrequentsController < ApplicationController
  # GET /frequents
  # GET /frequents.json
  def index
    @frequents = Frequent.all

    respond_to do |format|
      format.html # index.html.erb
      format.json { render json: @frequents }
    end
  end

  # GET /frequents/1
  # GET /frequents/1.json
  def show
    @frequent = Frequent.find(params[:id])

    respond_to do |format|
      format.html # show.html.erb
      format.json { render json: @frequent }
    end
  end

  # GET /frequents/new
  # GET /frequents/new.json
  def new
    @frequent = Frequent.new

    respond_to do |format|
      format.html # new.html.erb
      format.json { render json: @frequent }
    end
  end

  # GET /frequents/1/edit
  def edit
    @frequent = Frequent.find(params[:id])
  end

  # POST /frequents
  # POST /frequents.json
  def create
    @frequent = Frequent.new(params[:frequent])

    respond_to do |format|
      if @frequent.save
        format.html { redirect_to @frequent, notice: 'Frequent was successfully created.' }
        format.json { render json: @frequent, status: :created, location: @frequent }
      else
        format.html { render action: "new" }
        format.json { render json: @frequent.errors, status: :unprocessable_entity }
      end
    end
  end

  # PUT /frequents/1
  # PUT /frequents/1.json
  def update
    @frequent = Frequent.find(params[:id])

    respond_to do |format|
      if @frequent.update_attributes(params[:frequent])
        format.html { redirect_to @frequent, notice: 'Frequent was successfully updated.' }
        format.json { head :no_content }
      else
        format.html { render action: "edit" }
        format.json { render json: @frequent.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /frequents/1
  # DELETE /frequents/1.json
  def destroy
    @frequent = Frequent.find(params[:id])
    @frequent.destroy

    respond_to do |format|
      format.html { redirect_to frequents_url }
      format.json { head :no_content }
    end
  end
end
