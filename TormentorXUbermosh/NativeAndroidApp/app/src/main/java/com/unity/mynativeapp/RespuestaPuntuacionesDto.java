package com.unity.mynativeapp;

public class RespuestaPuntuacionesDto {
    private int puntuacion;
    private String nom_usuario,contrasena;

    public RespuestaPuntuacionesDto(int puntuacion,String nom_usuario,String contrasena){
        this.puntuacion=puntuacion;
        this.nom_usuario=nom_usuario;
        this.contrasena=contrasena;
    }

    public int getPuntuacion() {
        return puntuacion;
    }
    public String getNom_usuario(){
        return nom_usuario;
    }

    public String getContrasena() {
        return contrasena;
    }
}
