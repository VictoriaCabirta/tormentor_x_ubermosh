using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorSonido : MonoBehaviour
{

    public AudioSource arma,sonEnemigos;
    public Slider barraSonido;
    public Toggle quitSonido;
    bool cambio = false;
    public bool inicio = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!inicio)
        {
            arma.volume = barraSonido.value;
            sonEnemigos.volume = barraSonido.value;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(cambio && !inicio)
        {
            arma.volume = barraSonido.value;
            sonEnemigos.volume = barraSonido.value;
            cambio = false;
        }

        barraSonido.onValueChanged.AddListener(delegate {
            PlayerPrefs.SetFloat("Volumen", barraSonido.value);
            cambio = true;
        });

    }
}
