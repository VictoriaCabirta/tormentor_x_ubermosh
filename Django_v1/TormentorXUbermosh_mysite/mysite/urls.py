from django.contrib import admin
from django.urls import path

urlpatterns = [
    #path('', include('fachada_rest.urls')),  
    path('admin/', admin.site.urls),
]
