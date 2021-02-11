package com.unity.mynativeapp.clienteYDto;
import com.unity.mynativeapp.clienteYDto.dtos.ListaPuntuacionesDto;

public interface ManejadorRespuestaPuntuaciones {
    void puntuacionesObtenidas(ListaPuntuacionesDto puntDto);
    void errorOcurrido(String mensajeError);
}
