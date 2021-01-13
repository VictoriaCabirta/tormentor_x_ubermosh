//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MoverEnemigo : MonoBehaviour
{
    //Variables que uso en este script
    #region Variables
    public float speed;
    private float vel;
    Transform posicionJugador;
    ControladorMenu ControladorMenu;
    #endregion

    //Metodo que se ejecuta al iniciar en juego
    void Awake()
    {

        //Con esto le das a entender a la maquina que estas buscando un gameobject que tiene el Tag Player
        posicionJugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
        ControladorMenu = GameObject.FindWithTag("MenuP").GetComponent<ControladorMenu>();

    }

    //Metodo que se ejecuta en cada frame
    void Update()
    {
    
        //Si esta en pausa, no se puede mover
        #region Pausado
        if (ControladorMenu.pausado)
            vel = 0;
        else
            vel = speed;
        #endregion

        //Se mueve hacia la posicion del player
        transform.position = Vector2.MoveTowards(transform.position, posicionJugador.position, vel * Time.deltaTime);
    
    }

}
