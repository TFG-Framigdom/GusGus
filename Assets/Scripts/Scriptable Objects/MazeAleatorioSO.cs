using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Scriptable Object ALG", menuName = "Scriptable Objects/MazeAleatorio")]
public class MazeAleatorioSO : ScriptableObject
{
    [SerializeField] public List<int> laberintoAleatorio;


}

