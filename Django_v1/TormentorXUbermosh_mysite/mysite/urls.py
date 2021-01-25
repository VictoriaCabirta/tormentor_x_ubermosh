from django.contrib import admin
from django.urls import path, include

urlpatterns = [
    path('', include('fachada_rest.urls')),  
    path('admin/', admin.site.urls),
]
