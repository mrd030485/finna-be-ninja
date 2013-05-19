class CreateRawTwitterPosts < ActiveRecord::Migration
  def change
    create_table :raw_twitter_posts do |t|
      t.binary   :rawdata, :null=> false
      t.boolean  :processed, :default=>false

      t.timestamps
    end
  end
end
