from django.db import models

class Usuarios(models.Model):
    nombre = models.CharField(max_length=100, unique=True)
    contrasena = models.CharField(max_length=100)
    puntuacion = models.IntegerField(default=0)
    
    def __str__(self):
		return self.nombre

