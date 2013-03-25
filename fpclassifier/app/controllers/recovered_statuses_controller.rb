class RecoveredStatusesController < ApplicationController
  # GET /recovered_statuses
  # GET /recovered_statuses.json
  def index
    @recovered_statuses = RecoveredStatus.all

    respond_to do |format|
      format.html # index.html.erb
      format.json { render json: @recovered_statuses }
    end
  end

  # GET /recovered_statuses/1
  # GET /recovered_statuses/1.json
  def show
    @recovered_status = RecoveredStatus.find(params[:id])

    respond_to do |format|
      format.html # show.html.erb
      format.json { render json: @recovered_status }
    end
  end

  # GET /recovered_statuses/new
  # GET /recovered_statuses/new.json
  def new
    @recovered_status = RecoveredStatus.new

    respond_to do |format|
      format.html # new.html.erb
      format.json { render json: @recovered_status }
    end
  end

  # GET /recovered_statuses/1/edit
  def edit
    @recovered_status = RecoveredStatus.find(params[:id])
  end

  # POST /recovered_statuses
  # POST /recovered_statuses.json
  def create
    @recovered_status = RecoveredStatus.new(params[:recovered_status])

    respond_to do |format|
      if @recovered_status.save
        format.html { redirect_to @recovered_status, notice: 'Recovered status was successfully created.' }
        format.json { render json: @recovered_status, status: :created, location: @recovered_status }
      else
        format.html { render action: "new" }
        format.json { render json: @recovered_status.errors, status: :unprocessable_entity }
      end
    end
  end

  # PUT /recovered_statuses/1
  # PUT /recovered_statuses/1.json
  def update
    @recovered_status = RecoveredStatus.find(params[:id])

    respond_to do |format|
      if @recovered_status.update_attributes(params[:recovered_status])
        format.html { redirect_to @recovered_status, notice: 'Recovered status was successfully updated.' }
        format.json { head :no_content }
      else
        format.html { render action: "edit" }
        format.json { render json: @recovered_status.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /recovered_statuses/1
  # DELETE /recovered_statuses/1.json
  def destroy
    @recovered_status = RecoveredStatus.find(params[:id])
    @recovered_status.destroy

    respond_to do |format|
      format.html { redirect_to recovered_statuses_url }
      format.json { head :no_content }
    end
  end
end
