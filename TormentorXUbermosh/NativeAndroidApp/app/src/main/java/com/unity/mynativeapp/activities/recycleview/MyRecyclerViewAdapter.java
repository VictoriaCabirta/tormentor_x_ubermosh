package com.unity.mynativeapp.activities.recycleview;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.unity.mynativeapp.R;

import java.util.List;

public class MyRecyclerViewAdapter extends RecyclerView.Adapter<MyViewHolder> {

    // private RespuestaComidasDto miDtoConLosDatosMasticados;
    private List<String> allTheData;

    /**
     * Método constructor
     */
    public MyRecyclerViewAdapter(List<String> dataSet) {
        this.allTheData = dataSet;
    }

    @NonNull
    @Override
    public MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        // Create a new view, which defines the UI of the list item
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.recycler_view_cell, parent, false);
        System.out.println("He creado un nuevo view holder");
        return new MyViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull MyViewHolder holder, int position) {
        TextView elTextViewDeLaCelda = holder.getTextView();
        String elTextoEnNuestroDatasetCorrespondienteALaPosicion = allTheData.get(position);
        elTextViewDeLaCelda.setText(elTextoEnNuestroDatasetCorrespondienteALaPosicion);
        System.out.println("Estoy pintando la posicion " + position + " en un view holder");
    }

    @Override
    public int getItemCount() {
        return allTheData.size();
    }
}
