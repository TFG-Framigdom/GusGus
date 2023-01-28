using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    private Tilemap cuadricula;
    public int dimensionX;
    public int dimensionY;
    public TileBase tile; 
    public Camera camara;
    

    // Start is called before the first frame update
    void Start()
    {
        cuadricula = GetComponent<Tilemap>();
        GenerarMapa();
        AjustarCamara();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerarMapa()
    {
        int InicioXNegativa = dimensionX / -2;
        int InicioYNegativa = dimensionY / -2;
        int InicioXPositiva = InicioXNegativa*-1;
        int IincioYPositiva = InicioYNegativa*-1;
        for (int x = InicioXNegativa; x < InicioXPositiva; x++)
        {
            for (int y = InicioYNegativa; y < IincioYPositiva; y++)
            {
                cuadricula.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
        //cuadricula.transform.position = new Vector3(0, 0, 0);
    }

    public void AjustarCamara()
    {
        float ancho = cuadricula.localBounds.size.x;
        float alto = cuadricula.localBounds.size.y;
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

    // public void EscalarMapa2()
    // {
    //     float anchoCamara = Screen.width;
    //     float altoCamara = Screen.height;
    //     if(dimensionX>=8){
    //         dimensionX = dimensionX * (int)anchoCamara/2;
    //         dimensionY = dimensionY * (int)altoCamara/2;
    //     }
    // }

}




