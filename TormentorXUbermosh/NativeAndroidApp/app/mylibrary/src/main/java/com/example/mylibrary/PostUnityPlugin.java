package com.example.mylibrary;

import android.util.Log;

public class PostUnityPlugin {

    public void ActivarPost(String nombre, String contrasena, int puntuacion, boolean crearUsuario){
        if(crearUsuario)
            NuevoUsuario(nombre, contrasena, puntuacion);
        else
            NuevaPuntuacion(nombre, contrasena, puntuacion);
    }

    public void NuevoUsuario(String nombre, String contrasena, int puntuacion){

        /*
        JSONObject cuerpoPeticion = generarJson(nombre, contrasena, puntuacion, true);
        JsonObjectRequest nuevousuario = new JsonObjectRequest(
                Request.Method.POST,
                url + "/usuario",
                cuerpoPeticion,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        Log.d("PETICION POST", "Completada con exito");
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        error.printStackTrace();
                        Log.d("PETICION POST", "FATAL ERROR");
                    }
                }
        );
        this.queue.add(nuevousuario); */

    }

    public void NuevaPuntuacion(String nombre, String contrasena, int puntuacion){

        /*
        JSONObject cuerpoPeticion = generarJson(nombre, contrasena, puntuacion, false);
        JsonObjectRequest nuevapuntuacion = new JsonObjectRequest(
                Request.Method.POST,
                url + "/usuario/"+nombre,
                cuerpoPeticion,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        Log.d("PETICION POST", "Completada con exito");
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        error.printStackTrace();
                        Log.d("PETICION POST", "FATAL ERROR");
                    }
                }
        );
        this.queue.add(nuevapuntuacion); */
    }

    /*
        private JSONObject generarJson(String nombre, String contrasena, int puntuacion, boolean tipo) {
        JSONObject jsonObject = new JSONObject();
        try {
            jsonObject.put("usuario", nombre);
            if(tipo)
                jsonObject.put("contrasena", contrasena);
            jsonObject.put("puntuacion", puntuacion);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return jsonObject;
    }
     */

}
