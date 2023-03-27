using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerStadistic : MonoBehaviour
{
    //public GameObject[] hearts;
    [SerializeField] private int life = 3;

    //GameOver
    public RectTransform finalizarPartida;
    private TimeController tiempo;

    public UnityEvent<int> OnHeathUpdate;
    


    void Start(){ 
        if(SceneManager.GetActiveScene().name == "GamePlay"){
            OnHeathUpdate.Invoke(life);          
        }else{
            life = PlayerPrefs.GetInt("Vidas");
            OnHeathUpdate.Invoke(life);
            
        }
           
    }




    public void PlayerHealth(){
        life++;
        OnHeathUpdate.Invoke(life);
    }

    public void PlayerDamage(){
        if(life == 1){
            PlayerDeath();
            life--;
            OnHeathUpdate.Invoke(life);
        }else{
            life--;
            OnHeathUpdate.Invoke(life);
        }
       
    }

    public void PlayerDeath(){
        this.gameObject.SetActive(false);
        finalizarPartida.gameObject.SetActive(true);
        DestroyEnemigues();
        tiempo = GameObject.Find("Tiempo").GetComponent<TimeController>();
        tiempo.StopTimer();
        tiempo.tiempoInvertido();
    }

    void DestroyEnemigues(){
        NavMeshAgent[] enemigos = FindObjectsOfType<NavMeshAgent>();
        foreach (var enemigo in enemigos)
        {
            Destroy(enemigo.gameObject);
        }
    }


}
