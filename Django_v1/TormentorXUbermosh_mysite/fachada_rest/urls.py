from django.urls import path
from . import rest_facade

urlpatterns = [
    path('puntuacion', rest_facade.obtener_puntuacion, name='get_puntuacion'),
    path('usuario/<nombre>',rest_facade.subirPuntuacion,name='post_subirpuntuacion'),
    path('usuario',rest_facade.registro,name='post_registro'),

]
