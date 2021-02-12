import json
import json
from .models import Usuarios

from django.http import HttpResponse,HttpResponseNotAllowed, JsonResponse

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

@csrf_exempt
def subirPuntuacion(request, nombre):
	#Es POST?, si no lo es devuelve un error
	if request.method != 'POST':
		return HttpResponseNotAllowed(['POST'])
	# Coje un usuario y mira si existe, y si no existe salta el  404
	try: 
		usuario = Usuarios.objects.get(nombre__exact=nombre)
	except Usuarios.DoesNotExist:
		return JsonResponse({"errorDescription": "Usuario no encontrado, prueba a registrarte o inténtalo más tarde"}, status=404)

	cuerpo_solicitud = json.loads(request.body)
	contrasenaPeticion = cuerpo_solicitud.get('contrasena')
	puntuacion = cuerpo_solicitud.get('puntuacion')
	contrasenaBBDD = usuario.contrasena
	puntuacionBBDD= usuario.puntuacion
	print (contrasenaBBDD)
	print (contrasenaPeticion)
	if contrasenaPeticion == contrasenaBBDD:
		if puntuacionBBDD<puntuacion:
			usuario.puntuacion=puntuacion
			usuario.save()
			return JsonResponse({"Description":"actualizado correctamente" }, status=200)
		else :
			return JsonResponse({"Description":"la puntuación no ha mejorado"}, status=200)
	return JsonResponse({"errorDescription": "Contraseña incorrecta"}, status=401)

@csrf_exempt

def registro(request):
	if request.method != 'POST':
		return HttpResponseNotAllowed(['POST'])
	cuerpo_solicitud = json.loads(request.body)
	nombre= cuerpo_solicitud.get('usuario')
	contrasenaPeticion = cuerpo_solicitud.get('contrasena')
	puntuacion=cuerpo_solicitud.get('puntuacion')
	try:
		usuario=Usuarios.objects.get(nombre__iexact=nombre)
		return JsonResponse({"errorDescription":"Nombre de usuario ya existe"},status=422)
	except Usuarios.DoesNotExist:
		nuevo_usuario= Usuarios(nombre=nombre,contrasena=contrasenaPeticion, puntuacion= puntuacion)
		nuevo_usuario.save()
		return JsonResponse({"Description":"Usuario creado correctamente"},status=201)

