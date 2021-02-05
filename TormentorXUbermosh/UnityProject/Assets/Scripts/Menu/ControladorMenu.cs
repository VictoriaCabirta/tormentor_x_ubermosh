//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{

    public GameObject menuInicio, menuOpciones;

    public bool inicio = false, pausado = false;

    void Update()
    {
        if (!inicio && Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuOpciones.activeSelf)
            {
                menuOpciones.SetActive(false);
                pausado = false;
            }
            else
            {
                BotonPausa();
            }


        }    
    }

    public void Salir(string escena)
    {
        //Si es el inicio, vuelve al menu opciones, sino, vuelve a la escena inicial
        if(inicio)
        {
            menuInicio.SetActive(true);
            menuOpciones.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(escena);
            menuOpciones.SetActive(false);
        }
    }

    public void Seguir()
    {
        menuOpciones.SetActive(false);
        pausado = false;
    }

    public void BotonPausa()
    {
        menuOpciones.SetActive(true);
        pausado = true;
    }

}
