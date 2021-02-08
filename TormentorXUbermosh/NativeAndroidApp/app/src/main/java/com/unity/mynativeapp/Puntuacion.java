package com.unity.mynativeapp;

public class Puntuacion {
    private int puntuacion;
    private String nom_usuario;


    public Puntuacion(int puntuacion,String nom_usuario){
        this.puntuacion=puntuacion;
        this.nom_usuario=nom_usuario;
    }

    public int getPuntuacion() {
        return puntuacion;
    }

    public String getNom_usuario() {
        return nom_usuario;
    }
}