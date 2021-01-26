import json

from .models import Usuarios

from django.http import HttpResponseNotAllowed, JsonResponse
from django.views.decorators.csrf import csrf_exempt

@csrf_exempt
def obtener_puntuacion(request):
    if request.method != 'GET':
        return HttpResponseNotAllowed(['GET'])

    puntuaciones = mostrar_lista_puntuacion()
    
    respuesta = []
    for usr in puntuaciones:
        info_jugadores = { 'nombre': usr.nombre, 'puntuacion': usr.puntuacion }
        respuesta.append(info_jugadores)

    respuesta = sorted(respuesta, key=ordenar_json, reverse=True)

    return JsonResponse(respuesta, safe=False, status=200)

def mostrar_lista_puntuacion():
    try:
        return Usuarios.objects.all()
    except Usuarios.DoesNotExist:
        return None

def ordenar_json(punt):
	return punt["puntuacion"]