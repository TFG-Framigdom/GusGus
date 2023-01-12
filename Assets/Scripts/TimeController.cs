using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    
    public int minutos;
    public int segundos;
    [SerializeField] Text tiempo;

    private float tiempoRestante;
    private bool timerIsRunning;

    void Awake()
    {
        tiempoRestante = (minutos * 60) + segundos;
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
                Debug.Log("Time's up!");
            }

            tiempo.text = string.Format("{0:00}:{1:00}", Mathf.Floor(tiempoRestante / 60), tiempoRestante % 60);
            Debug.Log(tiempo.text);
        }
    }
}
