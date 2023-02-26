using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemySpawner : MonoBehaviour
{
    
    public LecturaFicheroSO lectura;
    
    [Header("Dependencies")]
    public GameObject EnemyBasic;
    public GameObject EnemyBasicParent;


    public void InstantiateEnemyBasic()
    {
        GameObject enemy = GetEnemyBasic();
        enemy.transform.position = lectura.posicionEnemigoBasico;
        enemy.transform.parent = EnemyBasicParent.transform;
  
    }

    private GameObject GetEnemyBasic()
    {
        GameObject SceneEnemy = GameObject.FindGameObjectWithTag("EnemyBasic");

        if(SceneEnemy == null)
        {
            SceneEnemy = Instantiate(EnemyBasic, lectura.posicionEnemigoBasico, Quaternion.identity);
        
        }

        return SceneEnemy;
    }
}
