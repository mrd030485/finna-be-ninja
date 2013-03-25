class CreateRecoveredStatuses < ActiveRecord::Migration
  def change
    create_table :recovered_statuses do |t|
      t.string :status
      t.string :keywords

      t.timestamps
    end
  end
end
