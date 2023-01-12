using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


// using UnityEngine;
// using UnityEngine.UI;

// public class Countdown : MonoBehaviour
// {
//     public float timeTotal = 60f;
//     public Text timeRemainingText;

//     private float timeRemaining;
//     private bool timerIsRunning = false;

//     void Start()
//     {
//         timeRemaining = timeTotal;
//     }

//     void Update()
//     {
//         if (timerIsRunning)
//         {
//             timeRemaining -= Time.deltaTime;
//             timeRemainingText.text = timeRemaining.ToString("F2");

//             if (timeRemaining <= 0f)
//             {
//                 timerIsRunning = false;
//                 timeRemaining = 0f;
//                 // aqui se ejecutara un evento cuando se acabe la cuenta atras 
//                 Debug.Log("Time's up!");
//             }
//         }
//     }

//     public void StartTimer()
//     {
//         timerIsRunning = true;
//     }

//     public void StopTimer()
//     {
//         timerIsRunning = false;
//     }
// }
