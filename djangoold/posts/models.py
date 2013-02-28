from django.db import models

class statements(models.Model):
    author = models.CharField(max_length=30)
    text = models.CharField(max_length=140)
    timestamp = models.DateTimeField()
