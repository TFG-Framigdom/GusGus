using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStadistic : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;

     //GameOver
    public RectTransform finalizarPartida;
    private TimeController tiempo;


    void Start(){
        life = hearts.Length;
    }

    void ChekLife(){
        if(life<1){
            //Game Over
            Destroy(hearts[0].gameObject);
            PlayerDeath();

        }else if(life<2){
            Destroy(hearts[1].gameObject);

        }else if(life<3){
            Destroy(hearts[2].gameObject);
        }
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
