require 'test_helper'

class FooterControllerTest < ActionController::TestCase
  test "should get footer" do
    get :footer
    assert_response :success
  end

end
