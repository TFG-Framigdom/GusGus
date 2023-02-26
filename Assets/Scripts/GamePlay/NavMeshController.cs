// using UnityEngine;
// using UnityEngine.Tilemaps;
// using UnityEngine.AI;


// public class ControladorEnemigo : MonoBehaviour
// {
//     public NavMeshAgent navMeshAgente;
//     public GameObject jugador;
//     public Tilemap[] tilemaps;

//     public void ConstruirNavMeshAgent()
//     {
//         // Esperar a que se carguen los tilemaps y el jugador esté correctamente posicionado
//         Invoke("ConstruirNavMeshAgentLuegoDeEspera", 1f);
//     }

//     private void ConstruirNavMeshAgentLuegoDeEspera()
//     {
//         // Construir NavMesh
//         NavMeshBuilder.BuildNavMesh();

//         // Configurar NavMeshAgent para el enemigo
//         navMeshAgente.enabled = true;
//     }
// }

