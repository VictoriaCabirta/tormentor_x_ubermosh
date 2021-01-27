from django.http import HttpResponseRedirect
from django.shortcuts import get_object_or_404, render
from django.urls import reverse
from django.views import generic

from .models import Choice, Question

class IndexView(generic.ListView):
    template_name = 'fachada_rest/index.html'
    context_object_name = 'puntuaciones_list'

    def get_usuarios(self):
        return Usuarios.objects.order_by('puntuacion')[:20]
