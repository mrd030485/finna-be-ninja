require 'test_helper'

class RecoveredStatusesControllerTest < ActionController::TestCase
  setup do
    @recovered_status = recovered_statuses(:one)
  end

  test "should get index" do
    get :index
    assert_response :success
    assert_not_nil assigns(:recovered_statuses)
  end

  test "should get new" do
    get :new
    assert_response :success
  end

  test "should create recovered_status" do
    assert_difference('RecoveredStatus.count') do
      post :create, recovered_status: { keywords: @recovered_status.keywords, status: @recovered_status.status }
    end

    assert_redirected_to recovered_status_path(assigns(:recovered_status))
  end

  test "should show recovered_status" do
    get :show, id: @recovered_status
    assert_response :success
  end

  test "should get edit" do
    get :edit, id: @recovered_status
    assert_response :success
  end

  test "should update recovered_status" do
    put :update, id: @recovered_status, recovered_status: { keywords: @recovered_status.keywords, status: @recovered_status.status }
    assert_redirected_to recovered_status_path(assigns(:recovered_status))
  end

  test "should destroy recovered_status" do
    assert_difference('RecoveredStatus.count', -1) do
      delete :destroy, id: @recovered_status
    end

    assert_redirected_to recovered_statuses_path
  end
end
