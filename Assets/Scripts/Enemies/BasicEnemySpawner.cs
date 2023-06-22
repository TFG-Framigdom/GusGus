using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemySpawner : MonoBehaviour
{
    
    public LecturaFicheroSO lectura;
    
    [Header("Dependencies")]
    public GameObject EnemyBasic;
    public GameObject EnemyBasicParent;
    



    public void Start()
    {
        InitializePool();
        //lectura.posicionEnemigoBasicos.Clear();

    }


    private void InitializePool()
    {
        for (int i = 0; i < lectura.posicionEnemigoBasicos.Count; i++)
        {
            // Add the enemy to the pool
            GameObject enemy = GetEnemyBasic(i);

        }

    }

    
    // public void InstantiateEnemyBasic()
    // {
    //     GameObject enemy = GetEnemyBasic();
    //     enemy.transform.position = lectura.posicionEnemigoBasico;
    //     enemy.transform.parent = EnemyBasicParent.transform;
  
    // }

    private GameObject GetEnemyBasic(int i)
    {
        GameObject SceneEnemy = Instantiate(EnemyBasic, lectura.posicionEnemigoBasicos[i], Quaternion.identity, EnemyBasicParent.transform);

        return SceneEnemy;
    }
}
