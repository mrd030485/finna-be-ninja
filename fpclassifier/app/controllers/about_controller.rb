class AboutController < ApplicationController
  def index
    @stats = "<p>";
    @raw = RawTwitterPost.count
    @keywords = RecoveredStatus.count
    @freq = Frequent.count
    @post = Post.count

    @stats = @stats+"Raw Tweets:#{@raw}<br/>Usable Tweets:#{@keywords}<br/>"
    @stats = @stats+"Frequent Patterns:#{@freq}<br/>User Generated Posts:#{@post}<br/>"
  end
end
