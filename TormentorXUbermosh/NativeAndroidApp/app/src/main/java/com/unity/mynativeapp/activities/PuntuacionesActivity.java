package com.unity.mynativeapp.activities;

import android.content.Context;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.RecyclerView;
import androidx.appcompat.app.AlertDialog;
import androidx.recyclerview.widget.LinearLayoutManager;
import android.content.DialogInterface;
import android.content.SharedPreferences;

import com.android.volley.Response;
import com.android.volley.VolleyError;
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

        this.recyclerView = findViewById(R.id.recicle_view_puntuaciones);

        mostrarCargando();
        SharedPreferences prefs = getSharedPreferences(Conventions.PrefsName, Context.MODE_PRIVATE);
        String nombreUsuario = prefs.getString(Conventions.PrefsUsernameKey, null);
        Cliente.getInstance(this).obtenerPuntuaciones(new ManejadorRespuestaPuntuaciones() {
            @Override
            public void pauntuacionesObtenidas(ListaPuntuacionesDto puntuacinoesDto) {
                ocultarCargando();
                MyRecyclerViewAdapter miAdaptador = new MyRecyclerViewAdapter(puntuacinoesDto);
                recyclerView.setAdapter(miAdaptador);
                recyclerView.setLayoutManager(new LinearLayoutManager(context));
            }
            @Override
            public void onErrorResponse(VolleyError error) {
                System.out.println("ha habido un error. Disculpen las molestias");
                if (error.networkResponse != null) {
                    System.out.println("Codigo de error " + error.networkResponse.statusCode);
                }
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

}
