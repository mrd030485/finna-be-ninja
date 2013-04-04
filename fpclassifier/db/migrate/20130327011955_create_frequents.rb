class CreateFrequents < ActiveRecord::Migration
  def change
    create_table :frequents do |t|
      t.string :post
      t.string :keyword
      t.float :confidence
      t.timestamps
    end
  end
end
