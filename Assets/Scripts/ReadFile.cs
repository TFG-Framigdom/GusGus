using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadFile : MonoBehaviour
{

    public Button button{get {return GetComponent<Button>();}}
    public TextAsset textFile;
    [SerializeField] Prueba pruebaTiempo;

    void Start()
    {
        button.onClick.AddListener(ReadFileText);
        
    }
    void ReadFileText()
    {
        string[] lines = textFile.text.Split('\n');
        string cadena = "";
        string nmatriz1 = "";
        string nmatriz2 = "";
        int numeroTiempo = 0;
        for(int i = 0; i < lines.Length; i++)
        {
            if(lines[i].Contains("tamaño:")){
                cadena = lines[i].Replace("tamaño:", "");
                nmatriz1 = cadena.Split(',')[0];
                nmatriz2 = cadena.Split(',')[1];
                //Debug.Log(numeroTiempo);
            }
            if(lines[i].Contains("Tiempo")){
                cadena = lines[i].Replace("Tiempo:", "");
                //Debug.Log(numeroTiempo);
            }
        }
        Debug.Log(nmatriz1);
        Debug.Log(nmatriz2);

        numeroTiempo = int.Parse(cadena);
        Debug.Log(numeroTiempo);
        pruebaTiempo.tiempo = numeroTiempo;
    }        

}
