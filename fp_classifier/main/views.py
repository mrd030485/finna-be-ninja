from django.shortcuts import render_to_response
from django import template
from django.utils import timezone
from django.template import RequestContext
from main.models import *

projectRoot = '/home/dev/github/my-repos/finna-be-ninja'

def index(request):
    results = Page.objects.filter(page_name='index.html').order_by('-set_date')
    
    template_name = results[0].get_template()
    pageid = results[0].page
    
    f_base = open(projectRoot+"/fp_classifier/templates/"+template_name,'r')
    t = template.Template(f_base.read())
    f_base.close()
    
    results = Sections.objects.filter(page_id=pageid).filter(name='head_content')
    f_head = open(projectRoot+"/www/"+results[0].source,'r')
    htemp = template.Template(f_head.read())
    f_head.close()
    
    mRes = Menu.objects.filter(page=pageid).order_by('order')
    menu = "<ul>\n"
    for x in range(0,mRes.count()):
        menu = menu+'<li><a href="'+mRes[x].url+'">'+mRes[x].name+'</a></li>\n'

    menu = menu +"\n</ul>"
    mCont = template.Context({
        'menu':menu
    })

    titleRes=Title.objects.filter(page=pageid)
    title = '<title>'+titleRes[0].title+'</title>'

    results = Sections.objects.filter(page=pageid).filter(name='index_content')
    f_cont = open(projectRoot+"/www/"+results[0].source,'r')
    
    results = Sections.objects.filter(page=pageid).filter(name='index_footer')
    f_foot = open(projectRoot+"/www/"+results[0].source,'r')
    
    context = template.Context ({
        'content':f_cont.read(),
        'footer':f_foot.read(),
        'header':htemp.render(mCont),
        'title':title
    })
    
    f_page = open(projectRoot+'/fp_classifier/templates/index.html','w')
    f_page.write(t.render(context))
    f_page.close()
    
    return render_to_response('index.html', context_instance=RequestContext(request))

def about(request):
    results = Page.objects.filter(page_name='about.html').order_by('-set_date')
    
    template_name = results[0].get_template()
    pageid = results[0].page
    
    f_base = open(projectRoot+"/fp_classifier/templates/"+template_name,'r')
    t = template.Template(f_base.read())
    f_base.close()
    
    results = Sections.objects.filter(page=pageid).filter(name='head_content')
    f_head = open(projectRoot+"/www/"+results[0].source,'r')
    htemp = template.Template(f_head.read())
    f_head.close()
    
    mRes = Menu.objects.filter(page=pageid).order_by('order')
    menu = "<ul>\n"
    for x in range(0,mRes.count()):
        menu = menu+'<li><a href="'+mRes[x].url+'">'+mRes[x].name+'</a></li>\n'

    menu = menu +"\n</ul>"
    mCont = template.Context({
        'menu':menu
    })

    titleRes=Title.objects.filter(page=pageid)
    title = '<title>'+titleRes[0].title+'</title>'

    results = Sections.objects.filter(page=pageid).filter(name='about_content')
    f_cont = open(projectRoot+"/www/"+results[0].source,'r')
    
    results = Sections.objects.filter(page=pageid).filter(name='about_footer')
    f_foot = open(projectRoot+"/www/"+results[0].source,'r')
    
    context = template.Context ({
        'content':f_cont.read(),
        'footer':f_foot.read(),
        'header':htemp.render(mCont),
        'title':title
    })
    
    f_page = open(projectRoot+'/fp_classifier/templates/about.html','w')
    f_page.write(t.render(context))
    f_page.close()
    
    return render_to_response('about.html')
