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
        tiempo.StopTimer();

        enemigos = FindObjectOfType<BasicEnemyController>();
        enemigos.StopEnemigues();

        puntos = FindObjectOfType<PointController>();
        puntos.StopPoint();

        player.GetComponent<PlayerController>().enabled = false;

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
        tiempo.ResumeTimer();

        enemigos = FindObjectOfType<BasicEnemyController>();
        enemigos.ReadyEnemigues();

        puntos = FindObjectOfType<PointController>();
        puntos.ResumePoint();

        player.GetComponent<PlayerController>().enabled = true;
    }


}
