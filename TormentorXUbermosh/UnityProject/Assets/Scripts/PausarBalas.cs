using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarBalas : MonoBehaviour
{

    #region Variables
    ControladorMenu ControladorMenu;
    Rigidbody2D rb;

    private Vector2 ii;
    private float cont = 0;
    public float tiempoBala = 5;
    #endregion

    void Awake()
    {

        ControladorMenu = GameObject.FindWithTag("MenuP").GetComponent<ControladorMenu>();
        rb = GetComponent<Rigidbody2D>();

    }

    //Si hago esto en el awake no coge ningun valor
    private void Start()
    {
        ii = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        //Si esta en pausa, la vala tiene vector 0, si no, recuerda el vector original, asi como retoma el contador
        if (ControladorMenu.pausado)
            rb.velocity = Vector2.zero;
        else
        {
            rb.velocity = ii;
            cont += Time.deltaTime;

            if (cont >= tiempoBala)
                Destroy(gameObject);
        }

    }

}
