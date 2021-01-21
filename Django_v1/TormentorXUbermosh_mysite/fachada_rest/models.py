from django.db import models
import hashlib, binascii, os

class Usuarios(models.Model):
    nombre = models.CharField(max_length=100, unique=True)
    contrasena = models.CharField(max_length=100)
    puntuacion = models.IntegerField(default=0)

