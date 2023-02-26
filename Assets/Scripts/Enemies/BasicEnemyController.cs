using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class BasicEnemyController : MonoBehaviour
{
    
    private Transform player;
    private NavMeshAgent agent;
    private bool facingRight = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
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

    IEnumerator EsperarParaEncontrarJugador()
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

    // private void StopEnemy()
    // {
    //     if(player.)
    //     agent.isStopped = true;
    // }
}
