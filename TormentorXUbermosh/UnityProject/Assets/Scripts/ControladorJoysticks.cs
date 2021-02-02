using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJoysticks : MonoBehaviour
{

    public GameObject joysticks;
    EsPC EsPC;

    // Start is called before the first frame update
    void Awake()
    {
        EsPC = GameObject.FindGameObjectWithTag("EsPC").GetComponent<EsPC>();
    }

    void Start()
    {
        if (EsPC.esPC)
            joysticks.SetActive(false);
        /*else
            joysticks.SetActive(true);*/
    }

}
