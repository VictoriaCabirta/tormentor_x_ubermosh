package com.unity.mynativeapp.clienteYDto.dtos;
import java.util.List;

public class ListaPuntuacionesDto {
    private List<PuntuacionesDto> PuntuacionesMasAltas;

    public List<PuntuacionesDto> getPuntuacionesMasAltas() {
        return PuntuacionesMasAltas;
    }

    public ListaPuntuacionesDto(List<PuntuacionesDto> PuntuacionesMasAltas) {
        this.PuntuacionesMasAltas = PuntuacionesMasAltas;
    }
}
