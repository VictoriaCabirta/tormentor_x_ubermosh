using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador_registro : MonoBehaviour{
	
	public GameObject menuMuerte , registro, subPunt;
	public InputField textNombre, textContr;
	public Toggle NuevoUsuario;
	
	public void Registrarse(){
		menuMuerte.SetActive(false);
		registro.SetActive(true);
	}
	
	public void Volver(){
		registro.SetActive(false);
		menuMuerte.SetActive(true);
	}

	public void EnviarUsuario()
	{
		registro.SetActive(false);
		subPunt.SetActive(true);

		Debug.Log(textNombre.text);
		Debug.Log(textContr.text);

	}

	public void SubirPuntuacion()
    {

		if (NuevoUsuario.isOn)
		{
			Debug.Log("Se ha creado un nuevo usuario");
			//Metodo posto para nuevo usuario
		}
		else
		{
			Debug.Log("Se ha actualizado la puntuacion de un usuario");
			//Metodo post usuario ya existente
		}

		NoSubirPuntuacion();
    }

	public void NoSubirPuntuacion()
    {
		subPunt.SetActive(false);
		menuMuerte.SetActive(true);
	}

}