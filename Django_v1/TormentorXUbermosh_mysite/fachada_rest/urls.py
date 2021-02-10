from django.urls import path
from . import views
from . import rest_facade

app_name = 'fachada_rest'
urlpatterns = [
    path('tormentorxubermosh', views.pantallaPuntuaciones, name="main_view_puntuacion"),
    path('puntuacion', rest_facade.obtener_puntuacion, name='get_puntuacion'),
]
