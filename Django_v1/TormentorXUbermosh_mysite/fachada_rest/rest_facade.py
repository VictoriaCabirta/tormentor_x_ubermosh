import json
import os
import hashlib
from .models import Usuarios
from django.http import HttpResponse,HttpResponseNotAllowed, JsonResponse
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

	try: 
		usuario = Usuarios.objects.get(nombre__exact=nombre)
	except Usuarios.DoesNotExist:
		return JsonResponse({"errorDescription": "Usuario no encontrado, prueba a registrarte o inténtalo más tarde"}, status=404)
	
	cuerpo_solicitud = json.loads(request.body)
	puntuacion = cuerpo_solicitud.get('puntuacion')
	puntuacionBBDD=usuario.puntuacion
	if puntuacionBBDD<puntuacion:
		usuario.puntuacion=puntuacion
		usuario.save()
		return JsonResponse({"Description":"Has batido tu propio record. ¡Enhorabuena!" }, status=200)
	else :
		return JsonResponse({"Description":"La puntuación no ha mejorado"}, status=200)


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
		contrasenaBBDD = usuario.contrasena_hmac
		puntuacionBBDD = usuario.puntuacion
		print (contrasenaBBDD)
		print (contrasenaPeticion)
		if _calcular_contrasena_hmac(contrasenaPeticion, usuario.salt) == contrasenaBBDD:
			if puntuacionBBDD<puntuacion:
				usuario.puntuacion=puntuacion
				usuario.save()
				return JsonResponse({"Description":"Actualizado correctamente" }, status=200)
			else :
				return JsonResponse({"Description":"La puntuación no ha mejorado"}, status=200)
		return JsonResponse({"errorDescription":"Nombre de usuario ya existe o contraseña incorrecta"},status=422)
	except Usuarios.DoesNotExist:
		salt = os.urandom(32)
		contrasena_hmac = _calcular_contrasena_hmac(contrasenaPeticion, salt)
		nuevo_usuario= Usuarios(nombre=nombre,contrasena_hmac=contrasena_hmac,salt=salt,puntuacion= puntuacion)
		nuevo_usuario.save()
		return JsonResponse({"Description":"Usuario creado correctamente"},status=201)

def _calcular_contrasena_hmac(contrasena_sin_cifrar, salt):
	# Véase https://nitratine.net/blog/post/how-to-hash-passwords-in-python/
	return hashlib.pbkdf2_hmac('sha256', contrasena_sin_cifrar.encode('utf-8'), salt, 100000)
