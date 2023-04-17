using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NivelesUI : MonoBehaviour
{
 
    [SerializeField] Text nivel;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "GamePlay"){
            nivel.text = "Nivel 1";
        }else if(SceneManager.GetActiveScene().name == "GamePlayLevel2"){
            nivel.text = "Nivel 2";
        }else if(SceneManager.GetActiveScene().name == "GamePlayLevel3Finish"){
            nivel.text = "Nivel 3";
        }
    }
}
