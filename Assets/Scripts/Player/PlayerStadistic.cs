using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class PlayerStadistic : MonoBehaviour
{
    //public GameObject[] hearts;
    private int life;

     //GameOver
    public RectTransform finalizarPartida;
    private TimeController tiempo;

    public RectTransform Vidas;
    public GameObject vidaExtra;


    void Start(){ 
        life = Vidas.childCount;   
    }

    void ChekLife(){
        if(life<1){
            //Game Over
            Destroy(Vidas.GetChild(0).gameObject);
            PlayerDeath();

        }else if(life<2){
            Destroy(Vidas.GetChild(1).gameObject);

        }else if(life<3){
            Destroy(Vidas.GetChild(2).gameObject);

        }else if(life<4){
            Destroy(Vidas.GetChild(3).gameObject);
        }
    }

    public void PlayerHeal(){
        Transform lastHeart = Vidas.transform.GetChild(Vidas.transform.childCount - 1);
        GameObject newHeart = Instantiate(vidaExtra, Vidas.transform);
        if(Vidas.childCount == 1){
            newHeart.transform.position = lastHeart.position + new Vector3(Vidas.GetChild(0).GetComponent<RectTransform>().rect.width, 0, 0);
        }else if(Vidas.childCount == 2){
            newHeart.transform.position = lastHeart.position + new Vector3(Vidas.GetChild(1).GetComponent<RectTransform>().rect.width, 0, 0);
        }else if(Vidas.childCount == 3){
            newHeart.transform.position = lastHeart.position + new Vector3(Vidas.GetChild(2).GetComponent<RectTransform>().rect.width, 0, 0);
        }else if(Vidas.childCount == 4){
            newHeart.transform.position = lastHeart.position + new Vector3(Vidas.GetChild(3).GetComponent<RectTransform>().rect.width, 0, 0);
        }
        life++;

    }

    public void PlayerDamage(){
        life--;
        ChekLife();
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
