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


    void Awake()
    {
        tiempoRestante = segundos;
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            tiempoRestante -= Time.deltaTime;
            if(tiempoRestante < 1)
            {
                timerIsRunning = false;
                tiempoRestante = 0;
                finalizarPartida.gameObject.SetActive(true);
                player.SetActive(false);
                tiempoInvertido();


                Debug.Log("Time's up!");
            }

            tiempo.text = string.Format("{0:00}:{1:00}", Mathf.Floor(tiempoRestante / 60), tiempoRestante % 60);
            Debug.Log(tiempo.text);
        }
        else
        {
            tiempo.text = string.Format("{0:00}:{1:00}", Mathf.Floor(tiempoRestante / 60), tiempoRestante % 60);
        }
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
