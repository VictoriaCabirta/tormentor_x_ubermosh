package com.unity.mynativeapp.clienteYDto;

import android.app.AlertDialog;
import android.content.Context;
import android.content.SharedPreferences;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;
import com.unity.mynativeapp.clienteYDto.dtos.ListaPuntuacionesDto;
import com.unity.mynativeapp.clienteYDto.dtos.PuntuacionesDto;


import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;


public class Cliente {
    private static Cliente cliente;
    private String servidor ="http://192.168.0.73:8000";
    private RequestQueue queue;
    private Cliente(Context context) {
        this.queue = Volley.newRequestQueue(context);
    }
    public static Cliente getInstance(Context context) {
        if (cliente == null) {
            cliente = new Cliente(context);
        }
        return cliente;
    }

    public void obtenerPuntuaciones(final ManejadorRespuestaPuntuaciones handler) {
        JsonArrayRequest jsonRequest = new JsonArrayRequest(
                Request.Method.GET,
                //El Get de rest_facade de Django estaba hecho para devolver la lista ya ordenada
                servidor + "/puntuacion",
                null,
                new Response.Listener<JSONArray>() {
                    @Override
                    public void onResponse(JSONArray response) {
                        try {
                            List<PuntuacionesDto> lista = new ArrayList<>();
                            for (int i = 0; i<response.length(); i++) {
                                JSONObject puntuacionJson = response.getJSONObject(i);
                                String nombre = puntuacionJson.getString("nombre");
                                int puntuacion = puntuacionJson.getInt("puntuacion");
                                lista.add(new PuntuacionesDto(puntuacion,nombre));
                            }
                            handler.puntuacionesObtenidas(new ListaPuntuacionesDto(lista));
                        } catch (JSONException e) {
                            e.printStackTrace();
                            throw new RuntimeException();
                        }
                    }
                }, new Response.ErrorListener() {

            @Override
            public void onErrorResponse(VolleyError error) {
                handler.errorOcurrido("Ha ocurrido un error");
            }
        });
        queue.add(jsonRequest);
    }
/*
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

 */


}
