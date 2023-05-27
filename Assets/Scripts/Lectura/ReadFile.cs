using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Newtonsoft.Json;

public class ReadFile : MonoBehaviour
{

    public Button button{get {return GetComponent<Button>();}}
    public TextAsset jsonFile;
    [SerializeField] LecturaFicheroSO lectura;
    [SerializeField] MazeAleatorioSO mazeAleatorio;

    private int[,] matriz;

    void Start()
    {
        //WriteJSON("Assets/Files/JSON.json");
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ReadTextJSON);
        //WriteJSON("Assets/Files/JSON.json");
        
    }
    public void ReadTextJSON(){ 
        //Cambiar la forma de leer el archivo
        MazeSettings settings =  JsonUtility.FromJson<MazeSettings>(jsonFile.text);
        //Debug.Log(settings.Tamano[0] + "---------------------" +  settings.Tamano[1]);
        lectura.tiempo = settings.Tiempo;
        lectura.TamañoX = settings.Tamano[0];
        lectura.TamañoY = settings.Tamano[1];
        int[,] mazeValido = settings.CheckMazeBorders(settings.Laberinto);
        int[,] mazeValidoLevel2 = settings.CheckMazeBorders(settings.LaberintoLevel2);
        int[,] mazeValidoLevel3 = settings.CheckMazeBorders(settings.LaberintoLevel3);
        
        lectura.laberinto = mazeValido;
        lectura.laberintoLevel2 = mazeValidoLevel2;
        lectura.laberintoLevel3 = mazeValidoLevel3;

        
        

    }

    //MazeAleatorioSO
    public void WriteJSON(string filePath)
    {
        List<int> mazeData = mazeAleatorio.laberintoAleatorio;
        int[] tamano = new int[2];
        if( mazeData.Count == 144){
            tamano[0] = 12;
            tamano[1] = 12;
        }
        // Crear un objeto anónimo con los atributos "tiempo", "tamano" y "laberinto"
        var jsonObj = new
        {
            Tamano = tamano,
            Tiempo = 300,
            Laberinto = mazeData,
            LaberintoLevel2 = mazeData,
            LaberintoLevel3 = mazeData
        };

        // Convertir el objeto a una cadena de texto en formato JSON
        string jsonStr = JsonConvert.SerializeObject(jsonObj);

        // Escribir la cadena de texto en un archivo en la ruta especificada
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            File.WriteAllText(filePath, jsonStr);
        }else
        {
            File.WriteAllText(filePath, jsonStr);
        }
       
    }


}
