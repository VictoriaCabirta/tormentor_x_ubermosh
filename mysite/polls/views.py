desde django.http import HttpResponse
desde django.http import Http404
de django.shortcuts import render

de .models importar Pregunta

def index (solicitud):
    latest_question_list = Question.objects.order_by ('- pub_date') [: 5]
    template = loader.get_template ('polls / index.html')
    context = {'latest_question_list': latest_question_list,}
    return render (solicitud, 'polls / index.html', contexto)
    

def resultados (solicitud, question_id):
    response = "Estás viendo los resultados de la pregunta% s".
    return HttpResponse (respuesta% question_id)

def vote (solicitud, question_id):
    return HttpResponse ("Estás votando en la pregunta% s."% question_id)

def detalle (solicitud, question_id):
    question = get_object_or_404 (Pregunta, pk = question_id)
    return render (solicitud, 'polls / detail.html', {'question': question})
