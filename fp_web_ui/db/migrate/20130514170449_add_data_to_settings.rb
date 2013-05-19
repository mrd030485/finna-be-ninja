class AddDataToSettings < ActiveRecord::Migration
  def change
    add_column :settings, :data, :string
  end
end
