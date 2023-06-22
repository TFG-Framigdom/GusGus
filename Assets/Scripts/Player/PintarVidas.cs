using UnityEngine;

public class PintarVidas : MonoBehaviour
{

    [SerializeField]private RectTransform Vidas;

    [SerializeField]private int sizeVida = 18;

    public void UpdateCanvasUI(int puntosVidas){
        Vidas.sizeDelta = new Vector2(puntosVidas * sizeVida, Vidas.sizeDelta.y);
    }

}
