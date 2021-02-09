from django.db import models
import os

class Usuarios(models.Model):
    nombre = models.CharField(max_length=100, unique=True)
    puntuacion = models.IntegerField(default=0)
    contrasena = models.CharField(max_length=100,null=True)


