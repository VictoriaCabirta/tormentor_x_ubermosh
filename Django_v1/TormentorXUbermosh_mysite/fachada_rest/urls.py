from django.urls import path
from . import views
from . import rest_facade

urlpatterns = [
    path('puntuacion', rest_facade.obtener_puntuacion, name='get_puntuacion'),
    path('tormentorxubermosh/', views.IndexView.as_view(), name='main_view'),
]
