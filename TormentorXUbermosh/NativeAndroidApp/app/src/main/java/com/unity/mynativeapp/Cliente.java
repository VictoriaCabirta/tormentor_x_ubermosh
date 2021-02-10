package com.unity.mynativeapp;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.util.Log;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;


import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;


public class Cliente {
    private static Cliente cliente;
    private String servidor ="http://192.168.0.73:8000";
    private RequestQueue queue;
    private Cliente(Context context) {
        this.queue = Volley.newRequestQueue(context);
    }

    //Temporal para que las cosas no exploten ellas solas
    private String nombrUsuario = "Wuw", contraUsuario = "sep";
    private int puntuUsuario = 199;

//subir puntuacion
    private void subirPunt() {
        //final AlertDialog alertaCargando = AlertaCargando();
        //alertaCargando.show();
        JSONObject cuerpoPeticion = generarJson();
        JsonObjectRequest laPeticionQueVoyAMandar = new JsonObjectRequest(
                Request.Method.POST,
                servidor + "/score/<usuario>",
                cuerpoPeticion,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        //alertaCargando.hide();
                        //Shared preference es un comando para guardar datos tras el cierre de la aplicacion, asi que no nos hace falta
                        //SharedPreferences.Editor editor = getSharedPreferences(NombrePreferences, Context.MODE_PRIVATE).edit();
                        Log.d("PETICION POST", "Completada con exito");
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        //alertaCargando.hide();
                        error.printStackTrace();
                        Log.d("PETICION POST", "FATAL ERROR");
                    }
                }
        );

        //No entiendo bien esto, pero parece que asi funciona
        //RequestQueue queue = Volley.newRequestQueue(this);
        this.queue.add(laPeticionQueVoyAMandar);
    }

    //Metodo para generar el json
    //NOTA1: Cambiar nombre y puntuacion en el futuro por las variables que transmitan el valor
    //NOTA2: Tal y como esta ahora solo generaria el metodo para actualizar la puntuacion, asi que a futuro o se hace que tenga switch o bien hay varios metodos para hacer jsons
    private JSONObject generarJson() {
        JSONObject jsonObject = new JSONObject();
        try {
            jsonObject.put("name", nombrUsuario);
            jsonObject.put("puntuación", puntuUsuario);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return jsonObject;
    }

    //Esto es un simple cuadro de dialogo, que por lo que tengo entendido quizas seria mejor hacer un toas directamente y ya
    /*private AlertDialog AlertaCargando() {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage("Publicando puntuación...");
        builder.setCancelable(false);
        return builder.create();
    }*/







}
