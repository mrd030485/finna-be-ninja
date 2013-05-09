SimpleNavigation::Configuration.run do |navigation|
  navigation.items do |primary|
    primary.item :home, 'Home', root_path,:class=>"first"
    primary.item :recovered_statuses, 'Posts', recovered_statuses_path do |posts|
      posts.item :create, 'New', new_recovered_status_path 
    end
    primary.item :user, 'Profile',user_profile_path, :class=>"last"
    # you can also specify a css id or class to attach to this particular level
    # works for all levels of the menu
    # primary.dom_id = 'menu-id'
    # primary.dom_class = 'menu-class'

    # You can turn off auto highlighting for a specific level
    # primary.auto_highlight = false

  end

end
