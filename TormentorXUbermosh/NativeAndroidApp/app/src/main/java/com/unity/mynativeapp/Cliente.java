package com.unity.mynativeapp;

import android.content.Context;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.unity.mynativeapp.Manejadores.ManejadorRegistro;

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


// solicita el registro
    public void solicitarRegistro(String nombreUsuario, String contrasena, ManejadorRegistro handler) {
        JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(
                Request.Method.POST,
                servidor + "/usuario",
                crearCuerpoPeticion(nombreUsuario, contrasena),

                new Response.Listener<JSONObject>() {

                    @Override
                    public void onResponse(JSONObject response) {
                        try {
                            String descripcion = response.get("Description").toString();
                            handler.registroExitoso(token);
                        } catch (JSONException e) {
                            throw new RuntimeException();
                        }
                    }
                }, new Response.ErrorListener() {


            @Override
            public void onErrorResponse(VolleyError error) {
                if(error.networkResponse.data != null) {
                    try {
                        String cuerpoRespuesta = new String(error.networkResponse.data,"UTF-8");
                        JSONObject json = new JSONObject(cuerpoRespuesta);
                        String mensajeError = json.get("mensajeError").toString();
                        System.out.println(mensajeError);
                        handler.registroFallido(mensajeError);
                    } catch (UnsupportedEncodingException | JSONException e) {
                        throw new RuntimeException();
                    }
                }
            }
        });
        queue.add(jsonObjectRequest);
    }
    //Esto crea un cuerpo de petición para usarlo después en solic registro
    private JSONObject crearCuerpoPeticion(String nombreUsuario, String contrasena) {
        JSONObject cuerpoPeticion = new JSONObject();
        try {
            cuerpoPeticion.put("nombreUsuario", nombreUsuario);
            cuerpoPeticion.put("contrasena", contrasena);
            return cuerpoPeticion;
        } catch (JSONException e) {
            throw new RuntimeException();
        }
    }






}
