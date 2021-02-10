from django.shortcuts import render
from .models import Usuarios

def index(request):
    usuarios_list = Usuarios.objects.order_by('puntuacion')[:20]
    output = {'usuarios_list': usuarios_list, 'puntuacion': usr.puntuacion }
    return render(request, 'fachada_rest/tormentorxubermosh.html', output)

