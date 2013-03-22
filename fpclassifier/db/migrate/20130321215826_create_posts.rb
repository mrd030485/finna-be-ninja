class CreatePosts < ActiveRecord::Migration
  def change
    create_table :posts do |t|
      t.text :thought
      t.date :create_date
      t.string :keyword

      t.timestamps
    end
  end
end
