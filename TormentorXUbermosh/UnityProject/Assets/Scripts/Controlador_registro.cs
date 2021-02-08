using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;

public class Controlador_registro : MonoBehaviour {
	
	public GameObject menuMuerte , registro, subPunt;
	public TMP_InputField textNombre, textContr;
	public Toggle NuevoUsuario;
	public TextMeshProUGUI punt;

	//0 == No existe Usuario
	string postURL0 = "https://reqres.in/api/users";
	//1 == Existe Usuario
	string postURL1 = "https://reqres.in/api/users";

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
			//Metodo post para nuevo usuario
			PrepararJSON(0);
		}
		else
		{
			Debug.Log("Se ha actualizado la puntuacion de un usuario");
			//Metodo post usuario ya existente
			PrepararJSON(1);
		}

		NoSubirPuntuacion();

    }

	public void NoSubirPuntuacion()
    {
		subPunt.SetActive(false);
		menuMuerte.SetActive(true);
	}

	public void PrepararJSON(int tipo)
	{
		string json;
		if (tipo == 0)
        {

			ClaseUsuario usr = new ClaseUsuario();

			usr = new ClaseUsuario()
			{
				nombre = textNombre.text,
				contrasena = textContr.text,
				puntuacion = int.Parse(punt.text)
			};

			json = JsonUtility.ToJson(usr);

			Debug.Log(json);

		}
        else
        {

			postURL1 += "/" + textNombre.text;

			ClasePuntuacion usr = new ClasePuntuacion()
			{
				puntuacion = int.Parse(punt.text)
			};


			json = JsonUtility.ToJson(usr);

			Debug.Log(json);
			Debug.Log(postURL1);

		}

		StartCoroutine(SimplePostRequest(json, tipo));

	}

	[System.Obsolete]
	IEnumerator SimplePostRequest(string json, int tipo)
	{

		List<IMultipartFormSection> WWWForm = new List<IMultipartFormSection>();

		WWWForm.Add(new MultipartFormDataSection("Usuario", json));

		string postURL = null;

		if (tipo == 0)
			postURL = postURL0;
		else
			postURL = postURL1;

		UnityWebRequest www = UnityWebRequest.Post(postURL, WWWForm);

		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			Debug.LogError(www.error);
		}
		else
		{
			Debug.Log(www.downloadHandler.text);
			Debug.Log("Peticion completada satisfactoriamente");
		}
	}

}