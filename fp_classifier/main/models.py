from django.db import models
from django.contrib import admin

# Create your models here.
class PageId(models.Model):
    page_name = models.CharField(max_length=64)

class Page(models.Model):
    page = models.ForeignKey(PageId)
    template_name = models.CharField(max_length=64)
    page_name = models.CharField(max_length=64)
    set_date = models.DateTimeField()
    def __unicode__(self):
        return self.page_name+" "+self.template_name
    def get_template(self):
        return self.template_name

class Title(models.Model):
    page = models.ForeignKey(PageId)
    title = models.CharField(max_length=512) 
    set_date = models.DateTimeField()

class Menu(models.Model):
    page = models.ForeignKey(PageId)
    order = models.IntegerField()
    name = models.CharField(max_length=32)
    url = models.CharField(max_length=512)
    set_date = models.DateTimeField()

class Includes(models.Model):
    page = models.ForeignKey(PageId)
    type = models.CharField(max_length=64)
    url = models.CharField(max_length=1024)
    set_date = models.DateTimeField()

class Sections(models.Model):
    page = models.ForeignKey(PageId)
    font = models.CharField(max_length=64)
    name = models.CharField(max_length=64)
    source = models.CharField(max_length=1024)
    set_date = models.DateTimeField()

