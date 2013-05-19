class AddProcessDateToRawTwitterPosts < ActiveRecord::Migration
  def change
    add_column :raw_twitter_posts, :process_date, :timestamp
  end
end
