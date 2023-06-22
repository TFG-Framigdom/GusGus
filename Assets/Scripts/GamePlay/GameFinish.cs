using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class GameFinish : MonoBehaviour
{
    //GameOver
    public RectTransform finalizarPartida;

    public RectTransform niveles;

    public RectTransform panelPuntos;
    

    //Tiempo
    TimeController tiempo;
    // Scriptable Object
    public LecturaFicheroSO lectura;

    public LecturaFicheroItemsSO lecturaItems;

    private PointController puntosPantalla;
    



    void Start()
    {
        puntosPantalla = FindObjectOfType<PointController>();
        tiempo = GameObject.Find("Tiempo").GetComponent<TimeController>();
        lectura.posicionEnemigoBasicos.Clear();
        lecturaItems.posicionItemPuntos.Clear();
        

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            vidaPlayer();
            collision.gameObject.SetActive(false);
            StopEnemigues();
            tiempoPartida();
            TransicionDeScenes();
            OcultarPanel();
            PercentajePoints();
            //SavePointsPlayer();
            Debug.Log("Game Finished");
        } 
        
        
    }

    void tiempoPartida(){
        if(SceneManager.GetActiveScene().name == "GamePlayLevel3Finish"){
            tiempo.StopTimer();
            tiempo.tiempoInvertido();
        }
    }

   

    void StopEnemigues(){
        NavMeshAgent[] enemigos = FindObjectsOfType<NavMeshAgent>();
        foreach (var enemigo in enemigos)
        {
            enemigo.isStopped = true;
        }
    }

    void TransicionDeScenes(){
        if(SceneManager.GetActiveScene().name == "GamePlay"){
            SceneManager.LoadScene(2);
        }else if(SceneManager.GetActiveScene().name == "GamePlayLevel2"){
            SceneManager.LoadScene(3);
        }else if(SceneManager.GetActiveScene().name == "GamePlayLevel3Finish"){
            finalizarPartida.gameObject.SetActive(true);
        }
    }

    void vidaPlayer(){
        int vida = GameObject.Find("Player").GetComponent<PlayerStadistic>().life;
        lecturaItems.vidaPlayer = vida;
    }

    void OcultarPanel(){
        panelPuntos.gameObject.SetActive(false);
        niveles.gameObject.SetActive(false);
    }

    void PercentajePoints(){
        tiempo.PercentajePointsAboutTime();   
    }

    // void SavePointsPlayer(){
    //     puntosPantalla.SavePoints();
    // }
}

