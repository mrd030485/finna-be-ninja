class CreateFrequents < ActiveRecord::Migration
  def change
    create_table :frequents do |t|
      t.string :pattern
      t.float :confidence
      t.timestamps
    end
  end
end
