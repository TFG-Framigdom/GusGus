using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public LevelEntranceSO levelEntranceSO;

    public UnityEvent<string, int> OnScoreChanged;

    //public LeaderBoard leaderBoard;

    void Start()
    {
        SubmitScore();
    }

    public void SubmitScore()
    {   
        
        OnScoreChanged.Invoke(levelEntranceSO.username, levelEntranceSO.score);
    }
}
