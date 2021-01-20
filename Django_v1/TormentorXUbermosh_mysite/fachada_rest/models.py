from django.db import models

class Usuarios(models.Model):
    nombre = models.CharField(max_length=100, unique=True)
    ## Mejorar la contraseña
    contrasena = models.CharField(max_length=100)
    puntuacion = models.IntegerField(default=0)
    ##Tengo problemas con el Default de estos 3
    #token_sesion = models.CharField(max_length=100)
    #fecha_creacion = models.DateTimeField(auto_now_add=True)
    #fecha_modificacion = models.DateTimeField(auto_now=True)
    def __str__(self):
        return self.nombre
    
