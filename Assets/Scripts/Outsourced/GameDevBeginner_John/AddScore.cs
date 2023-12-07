// script from https://gamedevbeginner.com/how-to-keep-score-in-unity-with-loading-and-saving/#high_score_leaderboard with modifications
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public static AddScore addScore;
    public List<HighScoreEntry> scores = new List<HighScoreEntry>();

    private void Start()
    {
        addScore = this;
        
    }
     
    public void AddNewScore(string entryName, int entryScore)
    {
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore });
        Debug.Log("add score");
    }
}
