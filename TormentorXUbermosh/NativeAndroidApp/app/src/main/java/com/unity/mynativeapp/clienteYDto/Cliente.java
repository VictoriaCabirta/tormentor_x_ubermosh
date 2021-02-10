package com.unity.mynativeapp.clienteYDto;

import android.app.AlertDialog;
import android.content.Context;
import android.content.SharedPreferences;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;


import org.json.JSONException;
import org.json.JSONObject;


public class Cliente {
    private static Cliente cliente;
    private String servidor ="http://192.168.0.73:8000";
    private RequestQueue queue;
    private Cliente(Context context) {
        this.queue = Volley.newRequestQueue(context);
    }

//subir puntuacion
    private void subirPunt() {
        final AlertDialog alertaCargando = AlertaCargando();
        alertaCargando.show();
        JSONObject cuerpoPeticion = generarJson();
        JsonObjectRequest laPeticionQueVoyAMandar = new JsonObjectRequest(
                Request.Method.POST,
                servidor + "/score/<usuario>",
                cuerpoPeticion,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        alertaCargando.hide();
                        SharedPreferences.Editor editor = getSharedPreferences(NombrePreferences, Context.MODE_PRIVATE).edit();
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        alertaCargando.hide();
                        error.printStackTrace();
                    }
                }
        );

        RequestQueue queue = Volley.newRequestQueue(this);
        queue.add(laPeticionQueVoyAMandar);
    }

    private JSONObject generarJson() {
        JSONObject jsonObject = new JSONObject();
        try {
            jsonObject.put("name", nombre);
            jsonObject.put("puntuación", puntuacion);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return jsonObject;
    }

    private AlertDialog AlertaCargando() {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage("Publicando puntuación...");
        builder.setCancelable(false);
        return builder.create();
    }

  





}
