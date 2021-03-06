# encoding: UTF-8
# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# Note that this schema.rb definition is the authoritative source for your
# database schema. If you need to create the application database on another
# system, you should be using db:schema:load, not running all the migrations
# from scratch. The latter is a flawed and unsustainable approach (the more migrations
# you'll amass, the slower it'll run and the greater likelihood for issues).
#
# It's strongly recommended to check this file into your version control system.

ActiveRecord::Schema.define(:version => 20130514170449) do

  create_table "frequents", :force => true do |t|
    t.string   "pattern"
    t.float    "confidence"
    t.datetime "created_at", :null => false
    t.datetime "updated_at", :null => false
  end

  add_index "frequents", ["pattern"], :name => "pattern", :unique => true

  create_table "post_owners", :force => true do |t|
    t.integer  "user_id"
    t.integer  "recoverd_status_id"
    t.datetime "created_at",         :null => false
    t.datetime "updated_at",         :null => false
    t.boolean  "posted"
  end

  add_index "post_owners", ["recoverd_status_id"], :name => "index_post_owners_on_recoverd_status_id"

  create_table "raw_twitter_posts", :force => true do |t|
    t.binary   "rawdata",                         :null => false
    t.boolean  "processed",    :default => false
    t.datetime "created_at",                      :null => false
    t.datetime "updated_at",                      :null => false
    t.datetime "process_date"
  end

  create_table "recovered_statuses", :force => true do |t|
    t.text     "status"
    t.string   "keywords"
    t.boolean  "processed"
    t.datetime "created_at", :null => false
    t.datetime "updated_at", :null => false
  end

  create_table "settings", :force => true do |t|
    t.string   "name"
    t.boolean  "status"
    t.datetime "created_at", :null => false
    t.datetime "updated_at", :null => false
    t.string   "data"
  end

  create_table "twitter_accounts", :force => true do |t|
    t.integer  "user_id"
    t.boolean  "active"
    t.string   "oauth_token"
    t.string   "oauth_token_secret"
    t.string   "oauth_token_verifier"
    t.string   "nickname"
    t.string   "name"
    t.datetime "created_at",           :null => false
    t.datetime "updated_at",           :null => false
  end

  create_table "users", :force => true do |t|
    t.string   "email",                  :default => "", :null => false
    t.string   "encrypted_password",     :default => "", :null => false
    t.string   "reset_password_token"
    t.datetime "reset_password_sent_at"
    t.datetime "remember_created_at"
    t.integer  "sign_in_count",          :default => 0
    t.datetime "current_sign_in_at"
    t.datetime "last_sign_in_at"
    t.string   "current_sign_in_ip"
    t.string   "last_sign_in_ip"
    t.datetime "created_at",                             :null => false
    t.datetime "updated_at",                             :null => false
    t.boolean  "admin"
  end

  add_index "users", ["email"], :name => "index_users_on_email", :unique => true
  add_index "users", ["reset_password_token"], :name => "index_users_on_reset_password_token", :unique => true

end
