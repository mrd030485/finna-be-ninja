class CreatePostOwners < ActiveRecord::Migration
  def change
    create_table :post_owners do |t|
      t.integer :user_id
      t.references :recoverd_status

      t.timestamps
    end
    add_index :post_owners, :recoverd_status_id
  end
end
