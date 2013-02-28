from django.conf.urls import patterns, include, url

# Uncomment the next two lines to enable the admin:
from main import views
from django.contrib import admin
from posts import views
admin.autodiscover()

urlpatterns = patterns('',
    # Examples:
    # url(r'^$', 'fp_classifier.views.home', name='home'),
    # url(r'^fp_classifier/', include('fp_classifier.foo.urls')),

    # Uncomment the admin/doc line below to enable admin documentation:
    # url(r'^admin/doc/', include('django.contrib.admindocs.urls')),

    # Uncomment the next line to enable the admin:
    url(r'^admin/', include(admin.site.urls)),
    url(r'^about/$', 'main.views.about'),
    url(r'^submit/$', 'posts.views.submit'),
    url(r'^$', 'main.views.index'),
)
