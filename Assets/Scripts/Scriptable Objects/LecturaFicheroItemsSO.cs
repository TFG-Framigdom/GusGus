using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Object to iTEMS", menuName = "Scriptable Objects/Items")]
public class LecturaFicheroItemsSO : ScriptableObject
{
    [SerializeField] public Vector3 posicionItemTiempo;

    [SerializeField] public Vector3 posicionItemVida;



}
