using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Scriptable Object", menuName = "Scriptable Objects/LecturaFichero")]
public class LecturaFicheroSO : ScriptableObject
{
    [SerializeField] public int tiempo;

    [SerializeField] public float tiempoRestante;

    [SerializeField] public int TamañoX;

    [SerializeField] public int TamañoY;

    [SerializeField] public  Vector3 posicionJugador;
    
    [SerializeField] public int[,] laberinto;

    [SerializeField] public int[,] laberintoLevel2;

    [SerializeField] public List<Vector3> posicionEnemigoBasicos;

    [SerializeField] public Vector3 posicionEnemigoBasico;





}
