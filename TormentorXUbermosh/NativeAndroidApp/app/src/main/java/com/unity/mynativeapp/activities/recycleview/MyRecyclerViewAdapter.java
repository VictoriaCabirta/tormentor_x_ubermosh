package com.unity.mynativeapp.activities.recycleview;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.unity.mynativeapp.R;
import com.unity.mynativeapp.clienteYDto.dtos.ListaPuntuacionesDto;
import com.unity.mynativeapp.clienteYDto.dtos.PuntuacionesDto;

import java.util.List;

public class MyRecyclerViewAdapter extends RecyclerView.Adapter<MyViewHolder> {
    private ListaPuntuacionesDto listaPuntuacionesDto;

    public MyRecyclerViewAdapter(ListaPuntuacionesDto dataSet) {
        this.listaPuntuacionesDto = dataSet;
    }

    @NonNull
    @Override
    public MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.recycler_view_cell, parent, false);
        System.out.println("He creado un nuevo view holder");
        return new MyViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull MyViewHolder holder, int position) {
        PuntuacionesDto infoPuntuaciones = listaPuntuacionesDto.getPuntuacionesMasAltas().get(position);
        holder.getTextViewNombre().setText(infoPuntuaciones.getNom_usuario());
        holder.getTextViewPuntuacion().setText(String.valueOf(infoPuntuaciones.getPuntuacion()));
    }


    @Override
    public int getItemCount() {
        return listaPuntuacionesDto.getPuntuacionesMasAltas().size();
    }
}
