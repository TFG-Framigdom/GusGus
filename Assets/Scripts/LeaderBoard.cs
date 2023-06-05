using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private List<Text> names;
    [SerializeField]
    private List<Text> scores;

    private string publicKey =
    "6ac3dc68fa08c1e4079134418fb67511d0f489c075b7aecb9a02563a4d055c71";

    void Start()
    {
        GetLeaderBoard();
    }

    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
        {
            int loopLenght = (msg.Length > names.Count) ? names.Count : msg.Length;
           for(int i = 0;i < loopLenght; i++)
           {
               names[i].text = msg[i].Username;
               scores[i].text = msg[i].Score.ToString();
           }
        }));
    }

    public void SetLeaderBoard(string name, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicKey, name, score, ((msg) =>
        {
            GetLeaderBoard();
        }));
    }
}
