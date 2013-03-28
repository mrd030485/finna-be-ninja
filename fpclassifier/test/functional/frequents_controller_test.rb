require 'test_helper'

class FrequentsControllerTest < ActionController::TestCase
  setup do
    @frequent = frequents(:one)
  end

  test "should get index" do
    get :index
    assert_response :success
    assert_not_nil assigns(:frequents)
  end

  test "should get new" do
    get :new
    assert_response :success
  end

  test "should create frequent" do
    assert_difference('Frequent.count') do
      post :create, frequent: { keyword: @frequent.keyword, post: @frequent.post }
    end

    assert_redirected_to frequent_path(assigns(:frequent))
  end

  test "should show frequent" do
    get :show, id: @frequent
    assert_response :success
  end

  test "should get edit" do
    get :edit, id: @frequent
    assert_response :success
  end

  test "should update frequent" do
    put :update, id: @frequent, frequent: { keyword: @frequent.keyword, post: @frequent.post }
    assert_redirected_to frequent_path(assigns(:frequent))
  end

  test "should destroy frequent" do
    assert_difference('Frequent.count', -1) do
      delete :destroy, id: @frequent
    end

    assert_redirected_to frequents_path
  end
end
