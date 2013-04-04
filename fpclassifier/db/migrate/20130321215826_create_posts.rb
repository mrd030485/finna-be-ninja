class CreatePosts < ActiveRecord::Migration
  def change
    create_table :posts do |t|
      t.text :thought, :null => false
      t.string :keyword

      t.timestamps
    end
  end
end
