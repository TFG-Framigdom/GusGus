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
    [SerializeField] LecturaFicheroSO lectura;

    void Start()
    {
        button.onClick.AddListener(ReadFileText);
        
    }
    void ReadFileText()
    {
        string[] lines = textFile.text.Split('\n');
        string cadena = "";
        int numeroTiempo = 0;
        var values = new ArrayList(); 

        for(int i = 0; i < lines.Length; i++)
        {
            if(lines[i].Contains("tamaño:")){
                cadena = lines[i].Replace("tamaño:", "");
                string nmatriz1 = cadena.Split(',')[0];
                string nmatriz2 = cadena.Split(',')[1];
                lectura.TamañoX = int.Parse(nmatriz1);
                lectura.TamañoY = int.Parse(nmatriz2);
            }
            if(lines[i].Contains("Tiempo")){
                cadena = lines[i].Replace("Tiempo:", "");
                numeroTiempo = int.Parse(cadena);
                lectura.tiempo = numeroTiempo;
            }
            if(lines[i].Contains("Pjugador:")){
                cadena = lines[i].Replace("Pjugador:", "");
                string px = cadena.Split(',')[0];
                string py = cadena.Split(',')[1];
                lectura.posicionJugador = new Vector3(int.Parse(px), int.Parse(py), 0);
            }
            if(lines[i].Contains("Pmeta:")){
                cadena = lines[i].Replace("Pmeta:", "");
                string px = cadena.Split(',')[0];
                string py = cadena.Split(',')[1];
                lectura.posicionSalida = new Vector3(int.Parse(px), int.Parse(py), 0);
            }
            if(lines[i].Contains("filas")){
                cadena = lines[i].Replace("filas: ", "");
                string filaCadena = cadena.Replace(" ", "");
                for(int j = 0; j < filaCadena.Length - 1; j++)
                {
                    char numero = filaCadena[j];
                    int numeroInt = int.Parse(numero.ToString());
                    if(numeroInt == 1 || numeroInt == 0 || numeroInt == 2){
                        values.Add(numeroInt);               
                    }
                    
                }
            }
        }

        //lectura.values = values;

       
    }        

}
