require 'test_helper'

class RawTwitterPostsControllerTest < ActionController::TestCase
  setup do
    @raw_twitter_post = raw_twitter_posts(:one)
  end

  test "should get index" do
    get :index
    assert_response :success
    assert_not_nil assigns(:raw_twitter_posts)
  end

  test "should get new" do
    get :new
    assert_response :success
  end

  test "should create raw_twitter_post" do
    assert_difference('RawTwitterPost.count') do
      post :create, raw_twitter_post: { insert_date: @raw_twitter_post.insert_date, process_date: @raw_twitter_post.process_date, processed: @raw_twitter_post.processed, rawdata: @raw_twitter_post.rawdata }
    end

    assert_redirected_to raw_twitter_post_path(assigns(:raw_twitter_post))
  end

  test "should show raw_twitter_post" do
    get :show, id: @raw_twitter_post
    assert_response :success
  end

  test "should get edit" do
    get :edit, id: @raw_twitter_post
    assert_response :success
  end

  test "should update raw_twitter_post" do
    put :update, id: @raw_twitter_post, raw_twitter_post: { insert_date: @raw_twitter_post.insert_date, process_date: @raw_twitter_post.process_date, processed: @raw_twitter_post.processed, rawdata: @raw_twitter_post.rawdata }
    assert_redirected_to raw_twitter_post_path(assigns(:raw_twitter_post))
  end

  test "should destroy raw_twitter_post" do
    assert_difference('RawTwitterPost.count', -1) do
      delete :destroy, id: @raw_twitter_post
    end

    assert_redirected_to raw_twitter_posts_path
  end
end
