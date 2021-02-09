from django.db import models
import os

class Usuarios(models.Model):
    nombre = models.CharField(max_length=100, unique=True)
    contrasena_hmac = models.BinaryField(null=True)
    salt = models.BinaryField(default=os.urandom(32))
    puntuacion = models.IntegerField(default=0)


def __str__(self):
		return self.nombre
