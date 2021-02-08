package com.unity.mynativeapp;

public class RespuestaPuntuacionesDto {
    private int puntuacion;


    public RespuestaPuntuacionesDto(int puntuacion,String nom_usuario,String contrasena){
        this.puntuacion=puntuacion;
    }

    public int getPuntuacion() {
        return puntuacion;
    }

}
