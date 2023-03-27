using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintarVidas : MonoBehaviour
{

    private RectTransform Vidas;

    [SerializeField]private int sizeVida = 18;

    void Start()
    {
        Vidas = GetComponent<RectTransform>();
    }

    public void UpdateCanvasUI(int puntosVidas){
        Vidas.sizeDelta = new Vector2(puntosVidas * sizeVida, Vidas.sizeDelta.y);
    }

}
