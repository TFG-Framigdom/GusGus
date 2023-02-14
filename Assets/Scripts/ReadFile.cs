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
    public TextAsset jsonFile;
    [SerializeField] LecturaFicheroSO lectura;

    private int[,] matriz;

    void Start()
    {
        button.onClick.AddListener(ReadTextJSON);
        
    }
    void ReadTextJSON(){ 
        MazeSettings settings =  JsonUtility.FromJson<MazeSettings>(jsonFile.ToString());
        lectura.tiempo = settings.Tiempo;
        lectura.TamañoX = settings.Tamano[0];
        lectura.TamañoY = settings.Tamano[1];
        int[,] maze = settings.Convert2DArray();
    }


}
