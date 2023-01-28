using UnityEngine;

[CreateAssetMenu(fileName = "New Scene", menuName = "Scriptable Objects/Scene")]
public class SceneSO : ScriptableObject
{
    [Header("Scene Information")]
    public string sceneName;
}
