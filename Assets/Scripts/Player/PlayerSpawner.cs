using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject player;
    public LecturaFicheroSO lectura;
    public GameObject playerParent;


    
    public void InstantiatePlayer()
    {
        GameObject player = GetPlayer();
        player.transform.position = lectura.posicionJugador;
        player.transform.parent = playerParent.transform;
        
  
    }

    private GameObject GetPlayer()
    {
        GameObject ScenePlayer = GameObject.FindGameObjectWithTag("Player");

        if(ScenePlayer == null)
        {
            ScenePlayer = Instantiate(player, Vector3.zero, Quaternion.identity);
        }

        return ScenePlayer;
    }

}
