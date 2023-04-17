using UnityEngine;
using System.IO;
using UnityEditor;

public class FileBrowser : MonoBehaviour
{
    public void OpenFileBrowser() {
        string path = EditorUtility.OpenFilePanel("Open JSON file", "", "json");
        if (path.Length != 0) {
            string jsonString = File.ReadAllText(path);
            // Procesar el archivo JSON aquí
        }
    }
}
