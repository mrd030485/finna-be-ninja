from django.shortcuts import render_to_response
from django.http import HttpResponse
from django.template import Template, RequestContext
from posts.models import statements
from django.utils import timezone
from django.views.decorators.csrf import csrf_exempt

@csrf_exempt
def submit(request):
    #c={}
    #c.upate(csrf(request))
    p = statements(author=request.REQUEST['author'], text=request.REQUEST['text'], timestamp=timezone.now())
    p.save()
    return HttpResponse("Post #"+str(p.id)+" was submitted")
