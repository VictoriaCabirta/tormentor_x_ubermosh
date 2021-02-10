from django.shortcuts import render
from .models import Usuarios

def pantallaPuntuaciones(request):
    usuarios_list = Usuarios.objects.order_by('puntuacion')[:20]
    output = {'usuarios_list': usuarios_list, 'puntuacion': usuarios_list}
    return render(request, 'fachada_rest/tormentorxubermosh.html', output)

