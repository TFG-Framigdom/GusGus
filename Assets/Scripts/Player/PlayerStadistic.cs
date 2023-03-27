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

    public RectTransform Vidas;
    public GameObject vidaExtra;

    public UnityEvent<int> OnHeathUpdate;
    


    void Start(){ 
        // if(SceneManager.GetActiveScene().name == "GamePlay"){          
            
        // }else{
            
        //     Debug.Log("Vidas: " + life);
        //     PanelVidas();
            
        // }
        OnHeathUpdate.Invoke(life);
           
    }

    // void PanelVidas(){
    //     if(life == 1){
    //         Destroy(Vidas.GetChild(1).gameObject);
    //         Destroy(Vidas.GetChild(2).gameObject);
    //     }else if(life == 2){
    //         Destroy(Vidas.GetChild(2).gameObject);
    //     }else if(life == 4){
    //         GameObject newHeart = Instantiate(vidaExtra, Vidas.transform);
    //         newHeart.transform.position = Vidas.GetChild(3).position + new Vector3(Vidas.GetChild(3).GetComponent<RectTransform>().rect.width, 0, 0);
    //     }else{
    //         life = Vidas.childCount;
    //     }
    // }

    // void ChekLife(){
    //     if(life<1){
    //         //Game Over
    //         Destroy(Vidas.GetChild(0).gameObject);
    //         PlayerPrefs.SetInt("Vidas", life);
    //         PlayerDeath();

    //     }else if(life<2){
    //         Destroy(Vidas.GetChild(1).gameObject);
    //         PlayerPrefs.SetInt("Vidas", life);


    //     }else if(life<3){
    //         Destroy(Vidas.GetChild(2).gameObject);
    //         PlayerPrefs.SetInt("Vidas", life);


    //     }else if(life<4){
    //         Destroy(Vidas.GetChild(3).gameObject);
    //         PlayerPrefs.SetInt("Vidas", life);

    //     }
    // }

    public void PlayerHealth(){
        life++;
        OnHeathUpdate.Invoke(life);
    }

    public void PlayerDamage(){
        if(life == 0){
            PlayerDeath();
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
