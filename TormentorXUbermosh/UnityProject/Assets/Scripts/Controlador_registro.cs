using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;
using System.Text;

public class Controlador_registro : MonoBehaviour {
	
	public GameObject menuMuerte , registro, subPunt;
	public TMP_InputField textNombre, textContr;
	public Toggle NuevoUsuario;
	public TextMeshProUGUI punt;

	/*//0 == No existe Usuario
	//string postURL0 = "https://reqres.in/api/users";
	string postURL0 = "https://127.0.0.1:8000/usuario";
	//1 == Existe Usuario
	//string postURL1 = "https://reqres.in/api/users";
	string postURL1 = "http://127.0.0.1:8000/usuario";*/

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
			PrepararJSON(true);
		}
		else
		{
			Debug.Log("Se ha actualizado la puntuacion de un usuario");
			//Metodo post usuario ya existente
			PrepararJSON(false);
		}

		NoSubirPuntuacion();

    }

	public void NoSubirPuntuacion()
    {
		subPunt.SetActive(false);
		menuMuerte.SetActive(true);
	}

	public void PrepararJSON(bool nuevoUsuario)
	{

		AndroidJavaObject androidJO;

		androidJO = new AndroidJavaObject("com.example.mylibrary.PostUnityPlugin");

		if (nuevoUsuario)
        {
			Debug.Log("Enviando orden de un nuevo usuario");
			androidJO.Call("ActivarPost", textNombre.text, textContr.text, int.Parse(punt.text), true);
		}
        else
        {
			Debug.Log("Actualizando puntuacion de un usuario");
			androidJO.Call("ActivarPost", textNombre.text, textContr.text, int.Parse(punt.text), false);
		}

		/*string json;
		if (tipo == 0)
        {

			ClaseUsuario usr = new ClaseUsuario();

			usr = new ClaseUsuario()
			{
				usuario = textNombre.text,
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

		}*/

		//StartCoroutine(SimplePostRequest(json, tipo));

		//StartCoroutine(Upload());
		//StartCoroutine(CallLogin(postURL0));

		/*WWWForm formDate = new WWWForm();
		formDate.AddField("usuario", "qe");
		formDate.AddField("contrasena", "1234");
		formDate.AddField("puntuacion", 132);

		WWW www = new WWW(postURL0, formDate);

		Debug.Log(formDate);

		StartCoroutine(request(www));*/



	}


	/*IEnumerator Upload()
	{
		WWWForm form = new WWWForm();
		form.AddField("usuario", "qe");
		form.AddField("contrasena", "1234");
		form.AddField("puntuacion", 132);

		UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/usuario", form);
		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			Debug.LogError(www.error);
			Debug.LogError(form.headers);
			//Debug.LogError(form.data);
		}
		else
		{
			Debug.Log("Form upload complete!");
			Debug.Log(form.ToString());
			Debug.Log(form.data);
		}
	}


	public IEnumerator CallLogin(string url)
	{

		ClaseUsuario usr = new ClaseUsuario();

		usr = new ClaseUsuario()
		{
			usuario = textNombre.text,
			contrasena = textContr.text,
			puntuacion = int.Parse(punt.text)
		};

		string json = JsonUtility.ToJson(usr);

		var request = new UnityWebRequest(url, "POST");
		request.chunkedTransfer = false;
		byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
		request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
		request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
		request.SetRequestHeader("Content-Type", "application/json");
		yield return request.SendWebRequest();

		if (request.error != null)
		{
			Debug.LogError("Error");
			//Debug.LogError("Erro: " + www.error);
		}
		else
		{
			Debug.Log("All OK");
			Debug.Log("Status Code: " + request.responseCode);
		}

	}

	IEnumerator request (WWW www)
    {
		yield return www;

		Debug.Log("enviado");

	}


	IEnumerator SimplePostRequest(string json, int tipo)
	{

		/*WWWForm form = new WWWForm();
		form.AddField("myField", "myData");

		using (UnityWebRequest www = UnityWebRequest.Post("http://www.my-server.com/myform", form))
		{
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log("Form upload complete!");
			}
		}*/


	/*List<IMultipartFormSection> WWWForm = new List<IMultipartFormSection>();



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
		Debug.LogError("Fallo fatal");
	}
	else
	{
		Debug.Log(www.downloadHandler.text);
		Debug.Log("Peticion completada satisfactoriamente");
	}

	/*if (UnityWebRequest.Result == UnityWebRequest.Result.ConnectionError || UnityWebRequest.Result == UnityWebRequest.Result.ProtocolError)
	{
		Debug.LogError(www.error);
	}

}*/

}