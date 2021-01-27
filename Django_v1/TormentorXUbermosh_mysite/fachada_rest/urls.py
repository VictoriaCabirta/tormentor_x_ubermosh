from django.urls import path
from . import views
from . import rest_facade

app_name = 'fachada_rest'
urlpatterns = [
    path('puntuacion', rest_facade.obtener_puntuacion, name='get_puntuacion')
    path('',views.IndexView.as_view(), name='index'),
]
