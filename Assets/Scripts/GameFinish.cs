using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{
    //GameOver
    public RectTransform finalizarPartida;
    //Tiempo
    TimeController tiempo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            finalizarPartida.gameObject.SetActive(true);

            tiempo = GameObject.Find("Tiempo").GetComponent<TimeController>();
            tiempo.StopTimer();
            Debug.Log("si se ha parado el tiempo");
            tiempo.tiempoInvertido();
            Debug.Log("Game Finished");
        }
    }


}
