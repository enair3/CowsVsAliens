// script from https://gamedevbeginner.com/how-to-keep-score-in-unity-with-loading-and-saving/#high_score_leaderboard
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text scoreText;

    public void DisplayHighScore(string name, int score)
    {
        nameText.text = name;
        scoreText.text = string.Format("{0}", score);
    }

    public void HideEntryDisplay()
    {
        nameText.text = "";
        scoreText.text = "";
    }
}
