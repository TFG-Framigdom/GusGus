using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaCambiarEscena : MonoBehaviour
{

    public int IndiceEscena;

    public void CambiarEscena(int IndiceEscena)
    {
        SceneManager.LoadScene(IndiceEscena);
    }

}
