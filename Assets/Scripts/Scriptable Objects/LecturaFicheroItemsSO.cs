using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "New Scriptable Object to iTEMS", menuName = "Scriptable Objects/Items")]
public class LecturaFicheroItemsSO : ScriptableObject
{
    [SerializeField] public Vector3 posicionItemTiempo;

    [SerializeField] public Vector3 posicionItemVida;

    [SerializeField] public int vidaPlayer;

    [SerializeField] public List<Vector3> posicionItemPuntos;

    //[SerializeField] public int puntosPlayer;

}
