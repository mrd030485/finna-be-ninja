class CreateRecoveredStatuses < ActiveRecord::Migration
  def change
    create_table :recovered_statuses do |t|
      t.text :status
      t.string :keywords
      t.boolean :processed

      t.timestamps
    end
  end
end
