//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    //Variables que uso en este script
    #region Variables
    [SerializeField]
    private Transform arma;
    [SerializeField]
    private GameObject balaPrefab;
    [SerializeField]
    private bool player = false;

    //Solo si es un enemigo cabron
    Transform posicionJugador;
    private float contDisp = 0;
    [SerializeField]
    private float contMax = 3f;

    private Vector2 direccion;
    private float angulo;
    //public ControladorMenu ControladorMenu;
    ControladorMenu ControladorMenu;
    Joystick joystickArma;
    public GameObject fondoArma;
    AudioSource sourceDisparo;
    //public AudioClip clipDisparo;

    #endregion

    //Metodo que se ejecuta al iniciar en juego
    void Awake()
    {

        //Le decimos fijo que tine que buscar este componente
        ControladorMenu = GameObject.FindWithTag("MenuP").GetComponent<ControladorMenu>();
        joystickArma = GameObject.FindGameObjectWithTag("JoystickDisparo").GetComponent<Joystick>();

        //En relacion a si es player o enemigo, toma una accion u otra
        #region DifPlayerEnemigo
        //Si es le player (buscara el sonido) o si es el enemigo (buscara la posicion del player)
        if (!player)
            posicionJugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
        else
            sourceDisparo = GetComponent<AudioSource>();
        #endregion

    }

    //Metodo que se ejecuta en cada frame
    void Update()
    {

        //Esto es un contador que se actualiza constantemente
        contDisp += Time.deltaTime;

        //Angulo que le da al arma
        #region AnguloArma
        //Si es el player, va a buscar la posicion del raton, y si es el enemigo, la del player
        if (!player)
        {
            direccion = posicionJugador.position - transform.position;
        }
        else
        {

            direccion = joystickArma.Direction;
            //direccion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
        #endregion


        //Con esto, solo se podra disparar pasado un tiempo x
        #region Contador
        if (contDisp >= contMax)
        {
            //Esta condicion es para parar los procesos si esta el menu de pausa activo
            if (!ControladorMenu.pausado)
            {   
                //El enemigo, si o si disparara pasado el tiempo
                if (!player)
                {
                    Disparo();
                }
                else
                {

                    if (fondoArma.activeSelf)
                    {
                        Disparo();
                    }


                    //Si el player dispara, se genera la bala y el sonido del siparo
                    if (Input.GetMouseButtonDown(0))
                    {
                        
                        //Disparo();

                    }
                }
            }
        }
        #endregion

        //Esto son operaciones para que el arma gire libremente
        #region Actualizacion
        angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angulo - 90);
        #endregion

    }

    //Metodo que se hace para disparar
    public void Disparo()
    {

        if (player)
        {
            sourceDisparo.PlayOneShot(sourceDisparo.clip, 1);
        }

        //Con esto creamos un objeto el cual tiene las caracteristicas de ser una bala, la posicion actual (que es la pos del arma), y la rotacion del la misma
        GameObject bala = Instantiate(balaPrefab, arma.position, arma.rotation);

        //Con esto haces que vaya a una velocidad de 10 px (creo que son px) y que salga por la parte de arriba del arma
        bala.GetComponent<Rigidbody2D>().velocity = arma.up * 10;

        contDisp = 0;

    }

}
