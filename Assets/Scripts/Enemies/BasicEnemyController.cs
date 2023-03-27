using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class BasicEnemyController : MonoBehaviour
{
    
    private Transform player;
    private NavMeshAgent agent;
    private bool facingRight = false;

    private Vector2 posicionInicialJugador;

    public float tiempoEspera = 1f;

    public LecturaFicheroSO lectura;

    private List<GameObject> enemigosBasicos = new List<GameObject>();



    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemigosBasicosPantalla = GameObject.FindGameObjectsWithTag("EnemyBasic");
        foreach(GameObject enemigo in enemigosBasicosPantalla){
            enemigosBasicos.Add(enemigo);
        }
        agent = GetComponent<NavMeshAgent>();
        if(this.transform.rotation.x != 0)
            this.transform.rotation = Quaternion.identity;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        // Al principio del juego, el enemigo no tiene un jugador asignado, por lo que se debe esperar a que se encuentre uno.
        StartCoroutine(EsperarParaEncontrarJugador());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = agent.velocity;
        if(velocity.magnitude > 0.1f){
            if(velocity.x > 0 && !facingRight){
                Flip();
            }else if(velocity.x < 0 && facingRight){
                Flip();
            }
        }
        agent.SetDestination(player.position);
        
    }

    IEnumerator<GameObject> EsperarParaEncontrarJugador()
    {
        while (player == null)
        {
            PlayerController jugador = FindObjectOfType<PlayerController>();
            if (jugador != null)
            {
                player = jugador.transform;
            }
            yield return null;
        }
        

        // Aquí ya se tiene el transform del jugador, se puede usar para realizar cualquier acción que necesite.
    }

    private void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopEnemigues();
            //quitamos vida al jugador
            StartCoroutine(VolverAPosicionesIniciales());
        }
    }

    IEnumerator<WaitForSeconds> VolverAPosicionesIniciales()
    {
        yield return new WaitForSeconds(tiempoEspera);
        if(lectura.posicionEnemigoBasicos.Count == enemigosBasicos.Count){
            for(int i = 0; i < enemigosBasicos.Count ; i++){
                //Debug.Log("Posicion enemigos: " + i + " " + lectura.posicionEnemigoBasicos[i]);
                //desactivamos el enemigo para que se posicione en la posicion inicial sin errores
                enemigosBasicos[i].SetActive(false);
                enemigosBasicos[i].transform.position = lectura.posicionEnemigoBasicos[i];
                //activamos el enemigo para que vuelva a la vida
                enemigosBasicos[i].SetActive(true);
                //Debug.Log("Posicion enemigosGameObject:" + enemigosBasicos[i].transform.position);  
            }
        }
        posicionInicialJugador = lectura.posicionJugador;
        GameObject.FindGameObjectWithTag("Player").transform.position = posicionInicialJugador;
        yield return new WaitForSeconds(tiempoEspera);

        ReadyEnemigues();
    }

    public void StopEnemigues(){
        NavMeshAgent[] enemigos = FindObjectsOfType<NavMeshAgent>();
        foreach (var enemigo in enemigos)
        {
            enemigo.isStopped = true;
        }
    }

    void ReadyEnemigues(){
        NavMeshAgent[] enemigos = FindObjectsOfType<NavMeshAgent>();
        foreach (var enemigo in enemigos)
        {
            enemigo.isStopped = false;
        }
    }


}
