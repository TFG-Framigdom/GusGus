using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorShow : MonoBehaviour
{
    public float displayTime = 5f; // Tiempo en segundos que se mostrará el mensaje de error

    private float timer;

    [SerializeField] TextMeshProUGUI errorText;
    public RectTransform error;


    public void ShowError(string message)
    {
        errorText.text = message;
        error.gameObject.SetActive(true);
    }

    void Update()
    {
        if (error.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= displayTime)
            {
                error.gameObject.SetActive(false);
                timer = 0f;
            }
        }
    }
}
