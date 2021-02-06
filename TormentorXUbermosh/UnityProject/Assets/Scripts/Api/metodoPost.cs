using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

public class metodoPost : MonoBehaviour
{
    string postURL = "https://reqres.in/api/users";
    public Text txJSON;

    public void PrepararJSON()
    {
        ClaseUsuarios usr = new ClaseUsuarios();

        //usr.nombre = "as";

        usr = new ClaseUsuarios()
        {
            nombre = "Juan",
            contrasena = "Pedro",
            puntuacion = 5
        };

        string json = JsonUtility.ToJson(usr);

        //No entiendo para que es esta linea
        //usr = JsonUtility.FromJson<Usuario>(json);

        Debug.Log(json);

        StartCoroutine(SimplePostRequest(json));

    }

    [System.Obsolete]
    IEnumerator SimplePostRequest(string json)
    {

        List<IMultipartFormSection> WWWForm = new List<IMultipartFormSection>();

        WWWForm.Add(new MultipartFormDataSection("Usuario", json));

        UnityWebRequest www = UnityWebRequest.Post(postURL, WWWForm);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            txJSON.text = www.downloadHandler.text;
        }
    }
}
