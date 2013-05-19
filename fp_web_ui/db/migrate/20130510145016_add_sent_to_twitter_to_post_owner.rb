class AddSentToTwitterToPostOwner < ActiveRecord::Migration
  def change
    add_column :post_owners, :posted, :boolean
  end
end
