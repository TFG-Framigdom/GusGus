using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.AI;
using System.Collections;


public class GameFinish : MonoBehaviour
{
    //GameOver
    public RectTransform finalizarPartida;

    

    //Tiempo
    TimeController tiempo;
    // Scriptable Object
    public LecturaFicheroSO lectura;

    private GameObject enemigoBasico;


    void Start()
    {
        StartCoroutine(EsperarParaEncontrarAlEnemigo());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            finalizarPartida.gameObject.SetActive(true);
            StopEnemy();

            tiempo = GameObject.Find("Tiempo").GetComponent<TimeController>();
            tiempo.StopTimer();
            tiempo.tiempoInvertido();
            Debug.Log("Game Finished");
        }
        
        
    }

    void StopEnemy()
    { 
        NavMeshAgent navMeshAgent = enemigoBasico.GetComponent<NavMeshAgent>();
        //navMeshAgent.enabled = false;
        if(navMeshAgent.isActiveAndEnabled && navMeshAgent.isOnNavMesh){
            Debug.Log("Enemy Stopped");
            navMeshAgent.isStopped = true;
        }else{
            Debug.Log("Enemy Not Stopped");
        }
        //navMeshAgent.Stop();  
        
        //agentEnemy.GetComponent<NavMeshAgent>().isStopped = true;
    }

    IEnumerator EsperarParaEncontrarAlEnemigo()
    {
        while (enemigoBasico == null)
        {
            BasicEnemyController enemigo = FindObjectOfType<BasicEnemyController>();
            if (enemigo != null)
            {
                enemigoBasico = enemigo.gameObject;
            }
            yield return null;
        }

        // Aquí ya se tiene el transform del jugador, se puede usar para realizar cualquier acción que necesite.
    }

}
