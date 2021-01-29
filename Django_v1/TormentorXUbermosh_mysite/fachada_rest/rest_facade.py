import json

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
def login(request, nombre):
	#Es POST?, si no lo es devuelve un error
	if request.method != 'POST':
		return HttpResponseNotAllowed(['POST'])
	# Coje un usuario y mira si existe, y si no existe salta el  404
	try: 
		usuario = User.objects.get(nombre__exact=nombre)
	except Usuario.DoesNotExist:
		return JsonResponse({"errorDescription": "Usuario no encontrado, prueba a registrarte o inténtalo más tarde"}, status=404)

	cuerpo_solicitud = json.loads(request.body)
	contrasenaPeticion = cuerpo_solicitud.get('password')
	contrasenaBBDD = usuario.contrasena

	if contrasenaPeticion == contrasenaBBDD:
		# Genero un token de sesion
		random = secrets.token_urlsafe(64)
		respuesta = {"session_cookie": random}
		usuario.token_sesion = random
		usuario.save()
		return JsonResponse(mi_respuesta, status=200)
		
	return JsonResponse({"errorDescription": "Contraseña incorrecta"}, status=401)

@csrf_exempt

def registro(request):
	# Si recibimos una peticion que no es POST, devolvemos un 405
	if request.method != 'POST':
		return HttpResponseNotAllowed(['POST'])
	try:
		usuario=Usuario.objects.get(nombre__exact=nombre)
		return JsonResponse(("Nombre de usuario ya existe"),status=422)
	except Usuario.DoesNotExist:
		#obtener la contraseña que quieres asignar
		cuerpo_solicitud = json.loads(request.body)
		contrasenaPeticion = cuerpo_solicitud.get('password')
		usuario=Usuario.get.object(nombre='')
		#lanzar un token de sesion
		usuario.token_sesion = random
		usuario.save()
		password.save()
		return JsonResponse(("Usuario creado correctamente"),status=201)
	return JsonResponse(("No se ha podido leer la contraseña o el nombre de usuario"),status=400)


