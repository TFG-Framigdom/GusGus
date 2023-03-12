using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.AI;
using System.Collections.Generic;


public class GameFinish : MonoBehaviour
{
    //GameOver
    public RectTransform finalizarPartida;

    

    //Tiempo
    TimeController tiempo;
    // Scriptable Object
    public LecturaFicheroSO lectura;




    void Start()
    {
        lectura.posicionEnemigoBasicos.Clear();


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            finalizarPartida.gameObject.SetActive(true);
            StopEnemigues();

            tiempo = GameObject.Find("Tiempo").GetComponent<TimeController>();
            tiempo.StopTimer();
            tiempo.tiempoInvertido();
            Debug.Log("Game Finished");
        } 
        
        
    }

   

    void StopEnemigues(){
        NavMeshAgent[] enemigos = FindObjectsOfType<NavMeshAgent>();
        foreach (var enemigo in enemigos)
        {
            enemigo.isStopped = true;
        }
    }

}

