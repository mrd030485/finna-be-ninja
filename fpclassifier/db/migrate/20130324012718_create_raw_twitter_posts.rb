class CreateRawTwitterPosts < ActiveRecord::Migration
  def change
    create_table :raw_twitter_posts do |t|
      t.string :rawdata
      t.date :insert_date
      t.date :process_date
      t.boolean :processed

      t.timestamps
    end
  end
end
