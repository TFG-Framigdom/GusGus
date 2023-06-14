using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Scriptable Objects/Level/Level Entrance")]
public class LevelEntranceSO : ScriptableObject
{
    [SerializeField] public string username;

    [SerializeField] public int score;
 
   
}
