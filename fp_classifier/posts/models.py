from django.db import models

# Create your models here.
class Statement(models.Model):
    text = models.CharField(max_length=140)

class Keyword(models.Model):
    statement = models.ForeignKey(Statement)
    text = models.CharField(max_length=140)
