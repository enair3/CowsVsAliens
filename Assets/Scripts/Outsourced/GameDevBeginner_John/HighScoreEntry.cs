// script from https://gamedevbeginner.com/how-to-keep-score-in-unity-with-loading-and-saving/#high_score_leaderboard with some modifications
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreEntry
{
    public string name;
    public int score = PlayerController.playerInfo.cowCount;
}
