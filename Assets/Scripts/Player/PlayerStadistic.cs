using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerStadistic : MonoBehaviour
{
    //public GameObject[] hearts;
    public int life = 3;

    //GameOver
    public RectTransform finalizarPartida;
    private TimeController tiempo;

    public UnityEvent<int> OnHeathUpdate;

    public LecturaFicheroItemsSO lecturaItems;

    


    void Start(){ 
        if(SceneManager.GetActiveScene().name == "GamePlay"){
            OnHeathUpdate.Invoke(life);
        }else{
            life = lecturaItems.vidaPlayer;
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
        tiempo.PercentajePointAbouTimePlayerDeath();
        PointController puntos = FindObjectOfType<PointController>();
        puntos.ResetPoint();

    }

    void DestroyEnemigues(){
        NavMeshAgent[] enemigos = FindObjectsOfType<NavMeshAgent>();
        foreach (var enemigo in enemigos)
        {
            Destroy(enemigo.gameObject);
        }
    }



}
