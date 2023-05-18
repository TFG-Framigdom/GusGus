using UnityEngine;
using System.IO;
using UnityEditor;
using System.Collections.Generic;

public class FileBrowser : MonoBehaviour
{
    public void OpenFileBrowser() {
        string path = EditorUtility.OpenFilePanel("Open JSON file", "", "json");
        if (path.Length != 0) {
            if(ValidateJSONFile(path)){
                Debug.Log("El archivo es valido");
                //SaveFileBrowser();
            }
            //Debug.Log(jsonString);
        }
    }

    public void SaveFileBrowser() {
        string path = EditorUtility.SaveFilePanel("Save JSON file", "", "data", "json");
        if (path.Length != 0) {
            string jsonString = File.ReadAllText(path);
            Debug.Log(jsonString);
        }
    }

    private bool ValidateJSONFile(string filePath)
    {
        bool isValid = false;
        // Cargar el archivo JSON
        string jsonContent = File.ReadAllText(filePath);

        // Deserializar el contenido JSON en un diccionario
        Dictionary<string, object> jsonData = MiniJSON.Json.Deserialize(jsonContent) as Dictionary<string, object>;
        MazeSettings settings =  JsonUtility.FromJson<MazeSettings>(jsonContent);

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
                if(settings.Tamano.Length == 2 && settings.Tamano[0] == settings.Tamano[1]
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
