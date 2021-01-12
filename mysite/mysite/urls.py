from django.contrib import admin
from django.urls import include, path

app_name = 'polls'
urlpatterns = [
    path('polls/', include('polls.urls')),
    path('admin/', admin.site.urls),
]

