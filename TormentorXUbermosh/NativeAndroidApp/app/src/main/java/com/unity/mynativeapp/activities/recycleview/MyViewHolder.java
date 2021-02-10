package com.unity.mynativeapp.activities.recycleview;
import android.view.View;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.unity.mynativeapp.R;

public class MyViewHolder extends RecyclerView.ViewHolder {
    private final TextView textView;

    public MyViewHolder(@NonNull View itemView) {
        super(itemView);
        textView = (TextView) itemView.findViewById(R.id.info_text);
    }

    public TextView getTextView() {
        return textView;
    }
}