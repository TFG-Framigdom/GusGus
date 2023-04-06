using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;



public class GameFinish : MonoBehaviour
{
    //GameOver
    public RectTransform finalizarPartida;

    

    //Tiempo
    TimeController tiempo;
    // Scriptable Object
    public LecturaFicheroSO lectura;

    public LecturaFicheroItemsSO lecturaItems;
    
    private float tiempoEscena;



    void Start()
    {
        lectura.posicionEnemigoBasicos.Clear();


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            vidaPlayer();
            collision.gameObject.SetActive(false);
            StopEnemigues();
            tiempoPartida();
            // tiempo = GameObject.Find("Tiempo").GetComponent<TimeController>();
            // tiempo.StopTimer();
            // tiempo.tiempoInvertido();
            TransicionDeScenes();
            Debug.Log("Game Finished");
        } 
        
        
    }

    void tiempoPartida(){
        if(SceneManager.GetActiveScene().name == "GamePlayLevel2"){
            tiempo = GameObject.Find("Tiempo").GetComponent<TimeController>();
            tiempo.StopTimer();
            tiempo.tiempoInvertido();
        }
    }

   

    void StopEnemigues(){
        NavMeshAgent[] enemigos = FindObjectsOfType<NavMeshAgent>();
        foreach (var enemigo in enemigos)
        {
            enemigo.isStopped = true;
        }
    }

    void TransicionDeScenes(){
        if(SceneManager.GetActiveScene().name == "GamePlay"){
            SceneManager.LoadScene(2);
        }else if(SceneManager.GetActiveScene().name == "GamePlayLevel2"){
            finalizarPartida.gameObject.SetActive(true);
        }
    }

    void vidaPlayer(){
        int vida = GameObject.Find("Player").GetComponent<PlayerStadistic>().life;
        lecturaItems.vidaPlayer = vida;
    }


}

