from django.urls import path

from . import rest_facade

urlpatterns = [
    path('puntuacion', rest_facade.obtener_tienda, name='get_puntuacion')
]
