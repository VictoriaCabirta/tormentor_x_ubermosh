//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigos : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float tiempoEnemigos = 5f;
    [SerializeField]
    private float contMax = 3f;
    private float contMaxInicial = 0;

    [SerializeField]
    private GameObject enemigo;
    [SerializeField]
    private bool en = true;

    ControladorMenu ControladorMenu;
    #endregion

    //Se activa al inicio del juego
    void Awake()
    {
        contMaxInicial = contMax;
        ControladorMenu = GameObject.FindWithTag("MenuP").GetComponent<ControladorMenu>();
    }

    //Se activa cada frame
    void Update()
    {

        //Tiempo que se suma cada segundo
        tiempoEnemigos += Time.deltaTime;

        //Si ha pasado un tiempo, puede generar un enemigo
        #region Enemigo
        if (!ControladorMenu.pausado && tiempoEnemigos >= contMax)
        {
            //Si es un genera enemigo, genera un enemigo, si no, es porque genera un generardor de enigo (busca un punto aleatorio en el mapa)
            if (!en)
            {

                Vector2 posAleat;

                posAleat = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
                GameObject malo = Instantiate(enemigo, posAleat, transform.rotation);

            }
            else
            {
                GameObject malo = Instantiate(enemigo, transform.position, transform.rotation);
            }


            tiempoEnemigos = 0;
            contMax = Random.Range(1, contMaxInicial);
        }
        #endregion

    }
}
