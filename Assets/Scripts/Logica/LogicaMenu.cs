using UnityEngine;
using UnityEngine.UI;
using Dan.Main;


public class LogicaMenu : MonoBehaviour
{

    public LevelEntranceSO levelEntranceSO;

    public void ConfiguracionMenuExit()
    {
        LeaderboardCreator.ResetPlayer();
        levelEntranceSO.score = 0;
        Application.Quit();
    }

    void OnApplicationQuit() {
        LeaderboardCreator.ResetPlayer();
        levelEntranceSO.score = 0;
    }


}
