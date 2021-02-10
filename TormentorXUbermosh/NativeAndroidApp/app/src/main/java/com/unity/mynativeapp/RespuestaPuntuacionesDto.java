package com.unity.mynativeapp;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class RespuestaPuntuacionesDto {
    private List<Puntuacion> Puntuacion;

    public RespuestaPuntuacionesDto(JSONArray jsonArray) {
        try {
            this.Puntuacion = new ArrayList<>();
            for (int i = 0; i<jsonArray.length(); i++) {
                JSONObject puntuacionLista = jsonArray.getJSONObject(i);
                String newNombre = puntuacionLista.getString("nombre");
                int newPuntuacion = puntuacionLista.getInt("puntuacion");
                Puntuacion puntuacion = new Puntuacion(newNombre, newPuntuacion);
                this.Puntuacion.add(puntuacion);
            }
        } catch (JSONException e) {
            e.printStackTrace();
            this.Puntuacion = new ArrayList<Puntuacion>();
        }
    }

    public List<Puntuacion> getpuntuacion() {
        return this.Puntuacion;
    }
}