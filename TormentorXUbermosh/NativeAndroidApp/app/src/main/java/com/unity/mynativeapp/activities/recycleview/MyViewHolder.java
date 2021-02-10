package com.unity.mynativeapp.activities.recycleview;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.unity.mynativeapp.R;

public class MyViewHolder extends RecyclerView.ViewHolder {
    private final TextView textViewNombre;
    private final TextView textViewPuntuacion;

    public MyViewHolder(@NonNull View itemView) {
        super(itemView);
        this.textViewNombre = itemView.findViewById(R.id.textViewCellNombre);
        this.textViewPuntuacion = itemView.findViewById(R.id.textViewCellPuntuacion);
    }

    public TextView getTextViewNombre() {
        return textViewNombre;
    }
    public TextView getTextViewPuntuacion() {
        return textViewPuntuacion;
    }

}