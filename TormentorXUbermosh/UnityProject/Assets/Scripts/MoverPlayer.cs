//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    //Variables que uso en este script
    #region Variables

    Joystick joystickMovimiento;

    public ControladorMenu ControladorMenu;
    public float speed;
    private float vel;
    #endregion

    void Awake()
    {
        joystickMovimiento = GameObject.FindGameObjectWithTag("joystickMovimiento").GetComponent<Joystick>();
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

        //En el caso de que pulses WASD, el jugador se movera en una posicion o en otra
        #region PusasTecla,Fiesta
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
        #endregion

        //Debug.Log(joystickMovimiento.Horizontal + " / " + joystickMovimiento.Vertical);

        #region MovimientoJoystick
        transform.position = new Vector2(transform.position.x + (joystickMovimiento.Horizontal / 10), transform.position.y + (joystickMovimiento.Vertical / 10));
        #endregion
    }
}
