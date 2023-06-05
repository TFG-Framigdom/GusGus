using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject player;

    public RectTransform menuPause;

    private TimeController tiempo;

    private BasicEnemyController enemigos;

    private PointController puntos;

    public RectTransform finalizarPartida;

    public void PauseGame(){
        menuPause.gameObject.SetActive(true);
        tiempo = GameObject.Find("Tiempo").GetComponent<TimeController>();
        enemigos = FindObjectOfType<BasicEnemyController>();
        puntos = FindObjectOfType<PointController>();
        if(enemigos != null ){
            tiempo.StopTimer();
            enemigos.StopEnemigues();
            puntos.StopPoint();
            player.GetComponent<PlayerController>().enabled = false;
        }else{
            tiempo.StopTimer();
            puntos.StopPoint();
            player.GetComponent<PlayerController>().enabled = false;
        }
        
        

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && finalizarPartida.gameObject.activeSelf == false){
            Debug.Log("Pausa");
            PauseGame();
        }
    }

    public void ResumeGame(){
        menuPause.gameObject.SetActive(false);
        tiempo = GameObject.Find("Tiempo").GetComponent<TimeController>();
        enemigos = FindObjectOfType<BasicEnemyController>();
        puntos = FindObjectOfType<PointController>();
        if(enemigos != null ){
            tiempo.ResumeTimer();
            enemigos.ReadyEnemigues();
            puntos.ResumePoint();
            player.GetComponent<PlayerController>().enabled = true; 
        }else{
            tiempo.ResumeTimer();
            puntos.ResumePoint();
            player.GetComponent<PlayerController>().enabled = true; 
        }
    }


}
