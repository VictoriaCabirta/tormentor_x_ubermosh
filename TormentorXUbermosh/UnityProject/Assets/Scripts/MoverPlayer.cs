//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    //Variables que uso en este script
    #region Variables

    Joystick joystickMovimiento;
    EsPC EsPC;

    public ControladorMenu ControladorMenu;
    public float speed;
    private float vel;
    #endregion

    void Awake()
    {
        joystickMovimiento = GameObject.FindGameObjectWithTag("joystickMovimiento").GetComponent<Joystick>();
        EsPC = GameObject.FindGameObjectWithTag("EsPC").GetComponent<EsPC>();
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

        //En el caso de que sea PC, pulsas WASD y el jugador se movera en una posicion o en otra
        #region PusasTecla,Fiesta
        if (EsPC.esPC)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + vel * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector2(transform.position.x - vel * Time.deltaTime, transform.position.y);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - vel * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector2(transform.position.x + vel * Time.deltaTime, transform.position.y);
            }
        }
        #endregion

        //Si no es pc, se movera en relacion a los joysticks
        #region MovimientoJoystick
        else if (!ControladorMenu.pausado)
            transform.position = new Vector2(transform.position.x + (joystickMovimiento.Horizontal / 10), transform.position.y + (joystickMovimiento.Vertical / 10));
        #endregion
    }
}
