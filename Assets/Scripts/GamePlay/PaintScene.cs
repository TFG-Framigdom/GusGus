using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class PaintScene : MonoBehaviour
{
    [Header("Tilemaps")]
    public Tilemap background;
    public Tilemap laberinto;
    //public Tilemap laberintoLevel2;
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

    public LecturaFicheroItemsSO lecturaItems;

    public UnityEvent OnCharactersSpawned;
    
    private int[,] maze;

    // private int[,] mazeLevel2;


    void Awake()
    {
        dimensionX = lectura.TamañoX;
        dimensionY = lectura.TamañoY;
        maze = lectura.laberinto;
        //mazeLevel2 = lectura.laberintoLevel2;
        //laberintoLevel2.transform.position = new Vector3(10f, 0, 0);
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "GamePlay"){
            maze = lectura.laberinto;
            GenerarMapa();
            AjustarCamara();
            CentrarCamara();
            CrearLaberinto();
            PosicionamientoDeCharacters();
        }
        else if(SceneManager.GetActiveScene().name == "GamePlayLevel2"){
            maze = lectura.laberintoLevel2;
            GenerarMapa();
            AjustarCamara();
            CentrarCamara();
            CrearLaberinto();
            PosicionamientoDeCharacters();

        }
        else{
            Debug.Log("No se ha podido cargar el nivel");
        }
        
        //CrearLaberintoLevel2();


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
        
        if(dimensionX == maze.GetLength(0) && dimensionY == maze.GetLength(1)){
            for (int filas = 0; filas < dimensionX; filas++)
            {
                for (int columnas = 0; columnas < dimensionY; columnas++)
                {
                    if(maze[filas,columnas] == 1){
                        //Invertimos las filas y las columnas para que el laberinto se pinte correctamente respecto al Tilemap
                        laberinto.SetTile(new Vector3Int(columnas, dimensionX - filas - 1 , 0), tileLaberinto);
                    }
                    else if(maze[filas,columnas] == 3){
                        //Invertimos las filas y las columnas para que el laberinto se pinte correctamente respecto al Tilemap
                        salida.SetTile(new Vector3Int(columnas, dimensionX - filas - 1, 0), tileSalida);
                    }
                    
                }
            }
        }
        else{
            Debug.Log("El tamaño del laberinto no coincide con el tamaño del mapa");
            Debug.Log("Tamaño del mapa: " + dimensionX + "x" + dimensionY);
            Debug.Log("Tamaño del laberinto: " + maze.GetLength(0) + "x" + maze.GetLength(1));
        }
    }

    public void PosicionamientoDeCharacters(){
        for (int filas = 0; filas < dimensionX; filas++)
            {
            for (int columnas = 0; columnas < dimensionY; columnas++)
                {
                    if(maze[filas,columnas] == 4){
                        //Invertimos las filas y las columnas para que el laberinto se pinte correctamente respecto al Tilemap
                        background.SetTile(new Vector3Int(columnas, dimensionX - filas - 1, 0), tilePosicionInicial);
                        lectura.posicionJugador = new Vector3(columnas+ 0.5f, dimensionX - filas - 1 + 0.5f, 0);
                    }else if(maze[filas,columnas]==52){
                        //Invertimos las filas y las columnas para que el laberinto se pinte correctamente respecto al Tilemap
                        lectura.posicionEnemigoBasicos.Add(new Vector3(columnas+ 0.5f, dimensionX - filas - 1 + 0.5f, 0));
                        //lectura.posicionEnemigoBasico = new Vector3(columnas+ 0.5f, dimensionX - filas - 1 + 0.5f, 0);

                    }else if(maze[filas,columnas]==22){
                        lecturaItems.posicionItemTiempo = new Vector3(columnas+ 0.5f, dimensionX - filas - 1 + 0.5f, 0);
                        
                    }else if(maze[filas,columnas]==21){
                        lecturaItems.posicionItemVida = new Vector3(columnas+ 0.5f, dimensionX - filas - 1 + 0.5f, 0);
                    }

                }
            }
            //Instanciamos al jugador respecto a la posición que hemos guardado
            OnCharactersSpawned.Invoke();
        }

    // public void CrearLaberintoLevel2(){
    //     if(dimensionX == mazeLevel2.GetLength(0) && dimensionY == mazeLevel2.GetLength(1)){
    //         for (int filas = 0; filas < dimensionX; filas++)
    //         {
    //             for (int columnas = 0; columnas < dimensionY; columnas++)
    //             {
    //                 if(mazeLevel2[filas,columnas] == 1){
    //                     //Invertimos las filas y las columnas para que el laberinto se pinte correctamente respecto al Tilemap
    //                     laberintoLevel2.SetTile(new Vector3Int(columnas, dimensionX - filas - 1 , 0), tileLaberinto);
    //                 }
    //                 else if(mazeLevel2[filas,columnas] == 3){
    //                     //Invertimos las filas y las columnas para que el laberinto se pinte correctamente respecto al Tilemap
    //                     salida.SetTile(new Vector3Int(columnas, dimensionX - filas - 1, 0), tileSalida);
    //                 }else{
    //                     background.SetTile(new Vector3Int(columnas, dimensionX - filas - 1, 0), tileBackground);
    //                 }
                    
    //             }
    //         }
    //     }
    //     else{
    //         Debug.Log("El tamaño del laberinto no coincide con el tamaño del mapa");
    //         Debug.Log("Tamaño del mapa: " + dimensionX + "x" + dimensionY);
    //         Debug.Log("Tamaño del laberinto: " + mazeLevel2.GetLength(0) + "x" + mazeLevel2.GetLength(1));
    //     }
    // }

}


