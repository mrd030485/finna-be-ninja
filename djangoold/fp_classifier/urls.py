from django.conf.urls import patterns, include, url

#admin.autodiscover()

urlpatterns = patterns('',
    url(r'^$', 'fp_classifier.views.index', name='index'),
    url(r'^about/$', 'fp_classifier.views.about', name='about'),
    url(r'^/submit/$', 'posts.views.submit', name='submit'),
    url(r'^submit/$', 'posts.views.submit', name='submit'),
    # Examples:
    # url(r'^$', 'fp_classifier.views.home', name='home'),
    # url(r'^fp_classifier/', include('fp_classifier.foo.urls')),

    # Uncomment the admin/doc line below to enable admin documentation:
    # url(r'^admin/doc/', include('django.contrib.admindocs.urls')),

    # Uncomment the next line to enable the admin:
 #   url(r'^admin/', include(admin.site.urls)),
)
