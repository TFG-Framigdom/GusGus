using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

public class PaintScene : MonoBehaviour
{
    [Header("Tilemaps")]
    public Tilemap background;
    public Tilemap laberinto;
    public Tilemap salida;

    [Header("Tiles")]
    public TileBase tileBackground;
    public TileBase tileLaberinto;
    public TileBase tileSalida;
    public TileBase tilePosicionInicial;
    

    private int dimensionX;
    private int dimensionY;
    
    [Header("Dependencies")]
    public Camera camara;

    public GameObject player;

    //Scriptable Object
    public LecturaFicheroSO lectura;

    //JSON
    public TextAsset jsonFile;


    private MazeSettings settings;

    public UnityEvent OnPlayerSpawned;
    

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
            camara.orthographicSize = (ancho / 2) + 1;
        }
        else
        {
            camara.orthographicSize = (alto / 2) + 1;
        }
    }
    public void CentrarCamara()
    {
        camara.transform.position = new Vector3(dimensionX / 2, dimensionY / 2, -10);
    }


    public void CrearLaberinto(){
        int[,] maze = settings.Convert2DArray();
        
        if(dimensionX == maze.GetLength(0) && dimensionY == maze.GetLength(1)){
            for (int filas = 0; filas < dimensionX; filas++)
            {
                for (int columnas = 0; columnas < dimensionY; columnas++)
                {
                    if(maze[filas,columnas] == 1){
                        laberinto.SetTile(new Vector3Int(columnas, dimensionX - filas - 1 , 0), tileLaberinto);
                    }
                    else if(maze[filas,columnas] == 3){
                        salida.SetTile(new Vector3Int(columnas, dimensionX - filas - 1, 0), tileSalida);
                    }
                    else if(maze[filas,columnas] == 4){
                        background.SetTile(new Vector3Int(columnas, dimensionX - filas - 1, 0), tilePosicionInicial);
                        lectura.posicionJugador = new Vector3(columnas+ 0.5f, dimensionX - filas - 1 + 0.5f, 0);
                    }
                    
                }
            }
            OnPlayerSpawned.Invoke();
        }
        else{
            Debug.Log("El tamaño del laberinto no coincide con el tamaño del mapa");
        }
    }




}
