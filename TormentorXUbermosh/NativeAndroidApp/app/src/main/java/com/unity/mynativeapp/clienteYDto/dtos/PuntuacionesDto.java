package com.unity.mynativeapp.clienteYDto.dtos;

public class PuntuacionesDto {
    private int puntuacion;
    private String nom_usuario;


    public PuntuacionesDto(int puntuacion,String nom_usuario){
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