using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;
using UnityEngine.Events;
using System;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    [SerializeField]
    private List<TextMeshProUGUI> ranking;

    public LevelEntranceSO levelEntranceSO;

    public List<string> namesList = new List<string>();


    private string publicKey =
    "6ac3dc68fa08c1e4079134418fb67511d0f489c075b7aecb9a02563a4d055c71";

    void Start()
    {
        if(levelEntranceSO.username != names[names.Count - 1].text)
        {
            SubmitScore();
        }
        else
        {
            SubmitScore();
            GetLeaderBoard();
        }
        //GetLeaderBoard();
            
            
        
    }

    public void SetLeaderBoard(string name, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicKey, name, score, ((msg) =>
        {
            GetLeaderBoard();
        }));
    }


    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
        {
            int loopLength = (msg.Length > names.Count) ? names.Count : msg.Length;

            // Limpiar los objetos de texto
            for (int i = 0; i < names.Count; i++)
            {
                ranking[i].text = string.Empty;
                names[i].text = string.Empty;
                scores[i].text = string.Empty;
            }

            // Asignar los datos en orden a los objetos de texto
            for (int i = 0; i < loopLength; i++)
            {
                ranking[i].text = (i + 1).ToString();
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();

                namesList.Add(msg[i].Username);
            }

        }));

        
    }

    public void GetLeaderBoardNameList()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
        {

            // Asignar los datos en orden a los objetos de texto
            for (int i = 0; i < msg.Length; i++)
            {
                namesList.Add(msg[i].Username);
            }

        }));
        
    }


    public void SubmitScore()
    {
        SetLeaderBoard(levelEntranceSO.username, levelEntranceSO.score);
    }

    public bool CheckUsernameRepeat(string name){
        for(int i = 0; i < namesList.Count; i++){
            if(name == namesList[i]){
                return true;
            }
        }
        return false;
    }
}
