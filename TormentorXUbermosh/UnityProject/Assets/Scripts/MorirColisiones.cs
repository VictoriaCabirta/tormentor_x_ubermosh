/*using System.Collections;
using System.Collections.Generic;*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MorirColisiones : MonoBehaviour
{

    //Variables que uso
    #region Variables
    public int puntos = 10;
    public Text puntosText;

    public GameObject muerte;

    ControladorMenu ControladorMenu;
    MorirSonidos MorirSonidos;

    [SerializeField]
    private int tipoObjeto = 0;
    //0 -> Player
    //1 -> Enemigo
    //2 -> Bala Player
    #endregion

    //Metodo que se ejecuta al iniciar en juego
    void Awake()
    {
        //Le dices a la variable a que hace referencia en concreto (mas que nada por los prefabs)
        ControladorMenu = GameObject.FindWithTag("MenuP").GetComponent<ControladorMenu>();
        MorirSonidos = GameObject.FindWithTag("MenuP").GetComponent<MorirSonidos>();
        puntosText = GameObject.FindGameObjectWithTag("Puntuacion").GetComponent<Text>();
    }

    //Metodos que se activan de distintas formas, dependiendo de a que objeto pertenece este script y el numero asignado
    #region Colisiones
    void OnTriggerEnter2D(Collider2D collision)
    {

        switch (tipoObjeto)
        {
            case 0:
                if (collision.gameObject.tag == "BalaEnemigo")
                    MuertePersonaje();
                break;
            case 1:
                if (collision.gameObject.tag == "BalaPlayer")
                {
                    MorirSonidos.cod = 1;
                    Destroy(gameObject);
                }
                break;
            case 2:
                if (collision.gameObject.tag == "Enemigo")
                    EnemigoMuerto();     
                break;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (tipoObjeto == 0 && col.gameObject.tag == "Enemigo")
        {
            MuertePersonaje();
        }
    }
    #endregion

    //Metodo cuando muere el player
    void MuertePersonaje()
    {
        MorirSonidos.cod = 2;
        muerte.SetActive(true);
        ControladorMenu.pausado = true;
    }

    //Metodo cuando muere un enemigo random
    void EnemigoMuerto()
    {

        int punt = int.Parse(puntosText.text);

        punt += 10;

        puntosText.text = punt.ToString();

        Destroy(gameObject);
    }

}
