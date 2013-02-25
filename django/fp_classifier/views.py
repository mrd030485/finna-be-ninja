from django.shortcuts import render_to_response 
from django import template
from django.utils import timezone

def index(request):
    ftitle = open('/home/dev/github/my-repos/finna-be-ninja/www/title.html','r')
    fhead = open('/home/dev/github/my-repos/finna-be-ninja/www/head.html','r')
    fcontent = open('/home/dev/github/my-repos/finna-be-ninja/www/content.html','r')
    ffooter = open('/home/dev/github/my-repos/finna-be-ninja/www/foot.html','r')
    fbase = open('/home/dev/workspace/django1/fp_classifier/fp_classifier/templates/base.html','r')
    t = template.Template(fbase.read())
    c = template.Context({
        'title':ftitle.read(),
        'header':fhead.read(),
        'content':fcontent.read(),
        'footer':ffooter.read()}
    )
    fbase.close()
    ftitle.close()
    fhead.close()
    fcontent.close()
    ffooter.close()
    findex = open('/home/dev/workspace/django1/fp_classifier/fp_classifier/templates/index.html','w')
    findex.write(t.render(c));
    findex.close()
    return render_to_response('index.html')

def about(request):
    fcontent = open('/home/dev/github/my-repos/finna-be-ninja/www/about/about.html','r')
    ftitle = open('/home/dev/github/my-repos/finna-be-ninja/www/title.html','r')
    fhead = open('/home/dev/github/my-repos/finna-be-ninja/www/head.html','r')
    ffooter = open('/home/dev/github/my-repos/finna-be-ninja/www/foot.html','r')
    fbase = open('/home/dev/workspace/django1/fp_classifier/fp_classifier/templates/base.html','r')
    t = template.Template(fbase.read())
    c = template.Context({
        'title':ftitle.read(),
        'header':fhead.read(),
        'content':fcontent.read(),
        'footer':ffooter.read()}
    )
    fbase.close()
    ftitle.close()
    fhead.close()
    fcontent.close()
    ffooter.close()
    fabout = open('/home/dev/workspace/django1/fp_classifier/fp_classifier/templates/about.html','w')
    fabout.write(t.render(c));
    fabout.close()
    return render_to_response('about.html')
