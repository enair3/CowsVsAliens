using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script from https://gamedevbeginner.com/how-to-keep-score-in-unity-with-loading-and-saving/#high_score_leaderboard with some modificitions
public class HighScores : MonoBehaviour
{
    public HighScoreDisplay[] highScoreDisplayArray;
    List<HighScoreEntry> scores = new List<HighScoreEntry>();
    void Start()
    {
        // Adds some test data
        //AddNewScore("John", PlayerController.playerInfo.cowCount);
        //AddNewScore("name", PlayerController.playerInfo.cowCount);
        UpdateDisplay();

    }
    void UpdateDisplay()
    {
        //AddNewScore("name", score);
        scores.Sort((HighScoreEntry x, HighScoreEntry y) => y.score.CompareTo(x.score));
        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < scores.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(scores[i].name, scores[i].score);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }
    }
    public void AddNewScore(string entryName, int entryScore)
    {
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore });
    }
}