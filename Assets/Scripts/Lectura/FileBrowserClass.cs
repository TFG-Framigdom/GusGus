using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using AnotherFileBrowser.Windows;


public class FileBrowserClass : MonoBehaviour
{

    public Button listo;

    private ErrorShow errorShow;

    public ReadFile readFile;


    public void OpenExplorer()
    {
        var bp = new BrowserProperties();
        bp.filter = "json files (*.json)|*.json";
        bp.title = "Open JSON file";
        bp.filterIndex = 0;

        errorShow = GetComponent<ErrorShow>();        

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            //Carga el contenido del archivo JSON
            string jsonContent = File.ReadAllText(path);
            //Do something with path(string)
            if (ValidateJSONFile(jsonContent))
            {
                readFile.jsonFile = new TextAsset(jsonContent);
                listo.gameObject.SetActive(true);
            }else{
                errorShow.ShowError("El archivo JSON no es válido.");
            }
        });
    }

    private bool ValidateJSONFile(string json)
    {
       bool isValid = false;

       // Deserializar el contenido JSON en un diccionario
       Dictionary<string, object> jsonData = MiniJSON.Json.Deserialize(json) as Dictionary<string, object>;
       MazeSettings settings =  JsonUtility.FromJson<MazeSettings>(json);

       if(jsonData == null || settings == null || jsonData.Count != 5){
           Debug.Log("El archivo JSON no es válido. No se pudo deserializar.");
           isValid = false;
       }
       else{
           // Verificar la estructura del JSON
           if (jsonData.ContainsKey("Tamano") &&
               jsonData.ContainsKey("Tiempo") &&
               jsonData.ContainsKey("Laberinto") &&
               jsonData.ContainsKey("LaberintoLevel2") &&
               jsonData.ContainsKey("LaberintoLevel3"))
           {
               if(settings.Tamano.Length == 2 && settings.Tamano[0] >= 4 && settings.Tamano[1] >= 4
                && settings.Tamano[0] == settings.Tamano[1]
               && settings.Tiempo > 0 
               && settings.Laberinto.Length == settings.Tamano[0] * settings.Tamano[1]
               && settings.LaberintoLevel2.Length == settings.Tamano[0] * settings.Tamano[1]
               && settings.LaberintoLevel3.Length == settings.Tamano[0] * settings.Tamano[1]){
                   Debug.Log("El archivo JSON es válido.");
                   isValid = true;

               }
               else{
                   Debug.Log("El archivo JSON no es válido. Los tipos de datos no son los esperados.");
                   isValid = false;

               }
           }
           else
           {
               Debug.Log("El archivo JSON no es válido. Faltan claves en el diccionario.");
               isValid = false;
           }
       }
        

       return isValid;
    }
}
