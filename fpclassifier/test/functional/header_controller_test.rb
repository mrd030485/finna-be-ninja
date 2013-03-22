require 'test_helper'

class HeaderControllerTest < ActionController::TestCase
  test "should get header" do
    get :header
    assert_response :success
  end

end
