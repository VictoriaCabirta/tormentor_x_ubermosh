from django.urls import path

from . import rest_facade

urlpatterns = [
    path('puntuacion', rest_facade.obtener_puntuacion, name='get_puntuacion'),
    path('usuario',rest_facade.login,name='login'),
    path('usuario/{username}',rest_facade.registro,name='registro'),
]
