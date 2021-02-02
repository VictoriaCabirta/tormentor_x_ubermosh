from django.db import models

class Usuarios(models.Model):
    nombre = models.CharField(max_length=100, unique=True)
    puntuacion = models.IntegerField(default=0)
    contrasena_hmac = models.BinaryField()
    salt = models.BinaryField()
    tokenSesion = models.CharField(max_length=200)
    verificado = models.BooleanField(default=False)
    fecha_creacion = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        representacion_en_string = self.nombre
        if self.verificado == True:
            representacion_en_string = representacion_en_string + " [Verificado]"
        else:
            representacion_en_string = representacion_en_string + " [No Verificado]"
        return representacion_en_string
