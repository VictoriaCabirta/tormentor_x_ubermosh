from django.db import models

class Usuarios(models.Model):
    nombre = models.CharField(max_length=100, unique=True)
    puntuacion = models.IntegerField(default=0)
    contrasena_hmac = models.BinaryField()
    salt = models.BinaryField()
    token_sesion = models.CharField(max_length=200)

def __str__(self):
		return self.nombre
