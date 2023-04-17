using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class TimeController : MonoBehaviour
{

    //public int minutos;
    public int segundos;
    [SerializeField] Text tiempo;
    [SerializeField] Text tiempoInvert;

    public float tiempoRestante;
    private bool timerIsRunning = false;

    private int tiempoRestanteInvertido;
    
    //GameOver
    public RectTransform finalizarPartida;

    public GameObject player;

    //Scriptable Object
    public LecturaFicheroSO lectura;

    private int segundosPartida;



    void Start()
    {
        segundosPartida = lectura.tiempo;
        if(SceneManager.GetActiveScene().name == "GamePlay"){
            segundos = lectura.tiempo;
            tiempoRestante = segundos;
            timerIsRunning = true;
        }else{
            segundos = (int)lectura.tiempoRestante;
            tiempoRestante = segundos;
            timerIsRunning = true;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            tiempoRestante -= Time.deltaTime;
            lectura.tiempoRestante = tiempoRestante;
            if(tiempoRestante < 1){
                finalizarPartida.gameObject.SetActive(true);
                tiempoInvertido();
                OnDisable();
                
            }

            tiempo.text = string.Format("{0:00}:{1:00}", Mathf.Floor(tiempoRestante / 60), tiempoRestante % 60);
        }
        else
        {
            tiempo.text = string.Format("{0:00}:{1:00}", Mathf.Floor(tiempoRestante / 60), tiempoRestante % 60);
        }
    }
    void OnDisable()
    {
        timerIsRunning = false;
        tiempoRestante = 0;
        if(player != null){
            player.SetActive(false);
        }
        StopEnemigues();
        Debug.Log("Time's up!");
    }
    public void tiempoInvertido(){
      if(SceneManager.GetActiveScene().name == "GamePlayLevel3Finish"){
        if(tiempoRestante>segundosPartida){
            //tiempoRestanteInvertido = 0;
            tiempoInvert.text = string.Format("{0:00}:{1:00}", Mathf.Floor(tiempoRestanteInvertido / 60), tiempoRestanteInvertido % 60);                
        }else{
            tiempoRestanteInvertido = segundosPartida - (int)tiempoRestante;
            tiempoInvert.text = string.Format("{0:00}:{1:00}", Mathf.Floor(tiempoRestanteInvertido / 60), tiempoRestanteInvertido % 60);
        }
      }
        
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    void StopEnemigues(){
        NavMeshAgent[] enemigos = FindObjectsOfType<NavMeshAgent>();
        foreach (var enemigo in enemigos)
        {
            enemigo.isStopped = true;
        }
    }

    public void ItemTimer(int tiempoItem){
        tiempoRestante += tiempoItem;
    }
}
