from django.shortcuts import render
from .models import Usuarios
from django.http import HttpResponseRedirect
from django.views import generic


class IndexView(generic.ListView):
    template_name = 'fachada_rest/tormentorxubermosh.html'
    context_object_name = 'puntuaciones_list'

    def get_queryset(self):
        usuarios_list = Usuarios.objects.order_by('puntuacion')[:20]
        output = ', '.join([u.nombre for u in usuarios_list])
        return HttpResponseRedirect(output)
