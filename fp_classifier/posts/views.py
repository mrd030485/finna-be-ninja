from django.shortcuts import render_to_response
from django import template
from django.utils import timezone
from django.template import RequestContext
from posts.models import *
from django.core.context_processors import csrf

projectRoot = '/home/dev/github/my-repos/finna-be-ninja'

def submit(request):
    c={}
    c.update(csrf(request))
    p = Statement(text=request.REQUEST['text'])
    p.save()
    cont=({
        'content':"Post #"+str(p.id)+" was submitted",
    })
    return render_to_response('base.html',cont)
