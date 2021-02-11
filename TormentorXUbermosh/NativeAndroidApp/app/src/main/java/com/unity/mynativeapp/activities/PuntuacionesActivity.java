package com.unity.mynativeapp.activities;

import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import com.unity.mynativeapp.R;
import com.unity.mynativeapp.activities.recycleview.MyRecyclerViewAdapter;
import com.unity.mynativeapp.clienteYDto.Cliente;
import com.unity.mynativeapp.clienteYDto.ManejadorRespuestaPuntuaciones;
import com.unity.mynativeapp.clienteYDto.dtos.ListaPuntuacionesDto;

public class PuntuacionesActivity extends AppCompatActivity {
    private RecyclerView recyclerView;
    private AlertDialog alertaCargando;
    private final Context context = this;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.puntuaciones);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        this.recyclerView = findViewById(R.id.recicle_view_puntuaciones);

        mostrarCargando();
        Cliente.getInstance(this).obtenerPuntuaciones(new ManejadorRespuestaPuntuaciones() {
            @Override
            public void puntuacionesObtenidas(ListaPuntuacionesDto puntuacinoesDto) {
                ocultarCargando();
                MyRecyclerViewAdapter miAdaptador = new MyRecyclerViewAdapter(puntuacinoesDto);
                recyclerView.setAdapter(miAdaptador);
                recyclerView.setLayoutManager(new LinearLayoutManager(context));
            }
            @Override
            public void errorOcurrido(String mensajeError) {
                ocultarCargando();
                AlertDialog.Builder builder = new AlertDialog.Builder(context);
                builder.setMessage(mensajeError);
                builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) { }
                });
                builder.create().show();
            }
        });
    }
    private void mostrarCargando() {
        if (this.alertaCargando == null) {
            AlertDialog.Builder builder = new AlertDialog.Builder(context);
            builder.setMessage("Cargando...");
            builder.setCancelable(false);
            this.alertaCargando = builder.create();
        }
        this.alertaCargando.show();
    }

    private void ocultarCargando() {
        this.alertaCargando.hide();
    }

}



