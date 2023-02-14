using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GameFinish : MonoBehaviour
{
    //GameOver
    public RectTransform finalizarPartida;

    //Tiempo
    TimeController tiempo;
    // Scriptable Object
    public LecturaFicheroSO lectura;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            finalizarPartida.gameObject.SetActive(true);

            tiempo = GameObject.Find("Tiempo").GetComponent<TimeController>();
            tiempo.StopTimer();
            tiempo.tiempoInvertido();
            Debug.Log("Game Finished");
        }
        
        
    }


}
