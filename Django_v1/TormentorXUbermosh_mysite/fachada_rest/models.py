from django.db import models
import hashlib, binascii, os

class Usuarios(models.Model):
    nombre = models.CharField(max_length=100, unique=True)
    contrasena = models.CharField(max_length=40,default=get_hashed_password(),unique=True)
    puntuacion = models.IntegerField(default=0)
    ##token_sesion = models.CharField(max_length=100)
    ##fecha_creacion = models.DateTimeField(auto_now_add=True)
    ##fecha_modificacion = models.DateTimeField(auto_now=True)

def get_hashed_password(plain_text_password):
    return hashlib.new("sha1", plain_text_password.encode())
    
def hash_password(password):
    """Hash a password for storing."""
    salt = hashlib.sha256(os.urandom(60)).hexdigest().encode('ascii')
    pwdhash = hashlib.pbkdf2_hmac('sha512', password.encode('utf-8'), salt, 100000)
    pwdhash = binascii.hexlify(pwdhash)
    return (salt + pwdhash).decode('ascii')
