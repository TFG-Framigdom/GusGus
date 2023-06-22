using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
   public static AudioScript instance;

   void Awake()
    {
        if(AudioScript.instance == null)
        {
            AudioScript.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
