/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{

    public GameObject menuInicio, menuOpciones;

    public void IniciarJuego(string escena)
    {
        SceneManager.LoadScene(escena, LoadSceneMode.Additive);
        menuInicio.SetActive(false);
    }

    public void Opciones()
    {
        menuInicio.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void Registrarse()
    {
        Debug.Log("HEHEHEHE NOP");
    }

    public void Salir()
    {
        Application.Quit();
    }

}
