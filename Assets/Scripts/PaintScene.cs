using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PaintScene : MonoBehaviour
{
    
    public Tilemap background;
    public Tilemap laberinto;
    public TileBase tileBackground;
    public TileBase tileLaberinto;

    private int dimensionX;
    private int dimensionY;

    public Camera camara;

    //Scriptable Object
    public LecturaFicheroSO lectura;

    public TextAsset jsonFile;

    private MazeSettings settings;

    

    void Awake()
    {
        dimensionX = lectura.TamañoX;
        dimensionY = lectura.TamañoY;
        settings =  JSONReader.ReadMazeSettings(jsonFile.ToString());
    }

    void Start()
    {
        GenerarMapa();
        AjustarCamara();
        CentrarCamara();
        CrearLaberinto();
    }

    public void GenerarMapa(){
        for (int x = 0; x < dimensionX; x++)
        {
            for (int y = 0; y < dimensionY; y++)
            {
                background.SetTile(new Vector3Int(x, y, 0), tileBackground);
            }
        }
    }
    
    public void AjustarCamara()
    {
        float ancho = background.localBounds.size.x;
        float alto = background.localBounds.size.y;
        float proporcion = ancho / alto;
        float proporcionCamara = (float)Screen.width / (float)Screen.height;
        if (proporcion > proporcionCamara)
        {
            camara.orthographicSize = ancho / 2;
        }
        else
        {
            camara.orthographicSize = alto / 2;
        }
    }
    public void CentrarCamara()
    {
        camara.transform.position = new Vector3(dimensionX / 2, dimensionY / 2, -10);
    }


    public void CrearLaberinto(){
        int[,] maze = settings.Convert2DArray();
        
        if(lectura.TamañoX == maze.GetLength(0) && lectura.TamañoY == maze.GetLength(1)){
            for (int filas = 0; filas < maze.GetLength(0); filas++)
            {
                for (int columnas = 0; columnas < maze.GetLength(1); columnas++)
                {
                    if(maze[filas,columnas] == 1){
                        laberinto.SetTile(new Vector3Int(filas, columnas, 0), tileLaberinto);
                    }
                }
            }
        }
        else{
            Debug.Log("El tamaño del laberinto no coincide con el tamaño del mapa");
        }
    }

}
