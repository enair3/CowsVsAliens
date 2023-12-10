// script from https://gamedevbeginner.com/how-to-keep-score-in-unity-with-loading-and-saving/#high_score_leaderboard with some modifications
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public static HighScores highScores;
    public HighScoreDisplay[] highScoreDisplayArray;
    List<HighScoreEntry> scores = new List<HighScoreEntry>();
    void Start()
    {
        scores = AddScore.addScore.scores;
        XMLManager.instance.Load();

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
                //AddNewScore(scores[i].name, scores[i].score);

                highScoreDisplayArray[i].DisplayHighScore(scores[i].name, scores[i].score);
                Debug.Log("Added");
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }
    }
    /*public void AddNewScore(string entryName, int entryScore)
    {
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore });
        Debug.Log("add score");
    }*/
}