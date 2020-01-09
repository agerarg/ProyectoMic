using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class PHPTestConexion : MonoBehaviour
{
    public Text Respuesta;
    public GameObject ComenzarButt;
    private bool CountTime=false;
    private float acumulatedTime=0;
    public void GetRequest()
    {
        ComenzarButt.SetActive(false);
        Respuesta.text = "Cargando...";
        StartCoroutine(ConectandoServer());
        CountTime = true;
        acumulatedTime = 0;
    }
    void Update()
    {
        acumulatedTime += Time.deltaTime;
    }
    IEnumerator ConectandoServer()
    {
        WWWForm form = new WWWForm();
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://45.32.168.197/ludodidactas/test.php", form))
        {
            yield return webRequest.SendWebRequest();
            ComenzarButt.SetActive(true);
            CountTime = false;
            if (webRequest.isNetworkError)
            {
                Respuesta.text = "No se pudo conectar con el server";
            }
            else
            {
                if (webRequest.responseCode == 200)
                {
                    JsonTestLudo jsnData = JsonUtility.FromJson<JsonTestLudo>(webRequest.downloadHandler.text);

                    Respuesta.text = "Respuesta: "+ jsnData.respuesta+" "+ Environment.NewLine + "Tiempo: "+ acumulatedTime.ToString("F2") + "seg";
                }
                else
                {
                    Respuesta.text = "Error";
                }
            }
        }
    }
}

[Serializable]
public class JsonTestLudo
{
    public string respuesta;
}