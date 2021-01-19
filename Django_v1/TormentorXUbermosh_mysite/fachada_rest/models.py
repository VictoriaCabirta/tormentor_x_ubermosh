from django.db import models

class Usuarios(models.Model):
    ##id = models.AutoField(primary_key=True)
    nombre = models.CharField(max_length=100, unique=True)
    contrasena = models.CharField(max_length=100)
    puntuacion = models.IntegerField(default=0)
    ##token_sesion = models.CharField(max_length=100)
    ##fecha_creacion = models.DateTimeField(auto_now_add=True)
    ##fecha_modificacion = models.DateTimeField(auto_now=True)

