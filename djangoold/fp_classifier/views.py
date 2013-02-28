from django.shortcuts import render_to_response 
from django import template
from django.utils import timezone
from django.template import RequestContext
projectRoot = '/home/dev/github/my-repos/finna-be-ninja'

def index(request):
    ftitle = open(projectRoot+'/www/title.html','r')
    fhead = open(projectRoot+'/www/head.html','r')
    fcontent = open(projectRoot+'/www/content.html','r')
    ffooter = open(projectRoot+'/www/foot.html','r')
    fbase = open(projectRoot+'/django/fp_classifier/templates/base.html','r')
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
    findex = open(projectRoot+'/django/fp_classifier/templates/index.html','w')
    findex.write(t.render(c));
    findex.close()
    return render_to_response('index.html',context_instance=RequestContext(request))

def about(request):
    ftitle = open(projectRoot+'/www/title.html','r')
    fhead = open(projectRoot+'/www/head.html','r')
    fcontent = open(projectRoot+'/www/about.html','r')
    ffooter = open(projectRoot+'/www/foot.html','r')
    fbase = open(projectRoot+'/django/fp_classifier/templates/base.html','r')
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
    fabout = open(projectRoot+'/django/fp_classifier/templates/about.html','w')
    fabout.write(t.render(c));
    fabout.close()
    return render_to_response('about.html',context_instance=RequestContext(request))
