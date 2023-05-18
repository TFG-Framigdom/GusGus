using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
    
    public LecturaFicheroItemsSO lectura;
    
    [Header("Dependencies")]
    public GameObject point;
    public GameObject pointParent;

    public void Start()
    {
        InitializeSpawner();

    }


    private void InitializeSpawner()
    {
        for (int i = 0; i < lectura.posicionItemPuntos.Count; i++)
        {
            GameObject exp = GetPoint(i);

        }

    }

    private GameObject GetPoint(int i)
    {
        GameObject ScenePoint = Instantiate(point, lectura.posicionItemPuntos[i], Quaternion.identity, pointParent.transform);

        return ScenePoint;
    }
}
