using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{

    //public int minutos;
    public int segundos;
    [SerializeField] Text tiempo;
    [SerializeField] Text tiempoInvert;

    private float tiempoRestante;
    private bool timerIsRunning = false;

    private int tiempoRestanteInvertido;
    
    //GameOver
    public RectTransform finalizarPartida;

    public GameObject player;

    //Scriptable Object
    public Prueba pruebaTiempo;


    void Start()
    {
        segundos = pruebaTiempo.tiempo;
        tiempoRestante = segundos;
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            tiempoRestante -= Time.deltaTime;
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
        Debug.Log("Time's up!");
    }
    public void tiempoInvertido(){
        if(tiempoRestante < 1)
        {
            tiempoRestanteInvertido = segundos;
        }
        tiempoRestanteInvertido = segundos - (int)tiempoRestante;
        tiempoInvert.text = string.Format("{0:00}:{1:00}", Mathf.Floor(tiempoRestanteInvertido / 60), tiempoRestanteInvertido % 60);
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }
}
