require 'test_helper'

class LogsControllerTest < ActionController::TestCase
  test "should get index" do
    get :index
    assert_response :success
  end

  test "should get error" do
    get :error
    assert_response :success
  end

  test "should get info" do
    get :info
    assert_response :success
  end

  test "should get debug" do
    get :debug
    assert_response :success
  end

end
