using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement sceneManager;
    public static SceneManagement Instance = null;
    //HighScores highScores;

    List<HighScoreEntry> scores = new List<HighScoreEntry>();
    public List<string> names;
    public List<string> randomNames = new List<string>() { "a", "b", "c", "d", "e", "f",
                                                            "g", "h", "i", "j", "k", "l",
                                                            "m", "n", "o", "p", "q", "r",
                                                            "s", "t", "u", "v", "w", "x", "y", "z"};
    public string entryName = new string(" ");

    private void Awake()
    {
        sceneManager = this;

        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            DontDestroyOnLoad(sceneManager);

            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;
        //scoreSaver = GameObject.Find("XMLManager");
        scores = AddScore.addScore.scores;
        names = AlienNames.alienNames.names;
    }

    // Update is called once per frame
    void Update()
    {
        // if happiness empty
        if (PlayerController.playerInfo.happiness <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Gameplay" )
            {
                Debug.Log("saving_noCowEnd");
                entryName = randomNames[Random.Range(0, randomNames.Count - 1)] + randomNames[Random.Range(0, randomNames.Count - 1)];
                //Debug.Log(AlienNames.alienNames.alienNameIndex);
                /*AddScore.addScore.AddNewScore(names[AlienNames.alienNames.alienNameIndex],
                                              PlayerController.playerInfo.cowCount); */
                AddScore.addScore.AddNewScore(entryName,
                                              PlayerController.playerInfo.cowCount);
                //AlienNames.alienNames.alienNameIndex++;
                SceneManager.LoadScene("GameOver_noCow_Cutscene");
                Debug.Log("done saving");
            }
            if (SceneManager.GetActiveScene().name == "Tutorial_game")
            {
                SceneManager.LoadScene("Tutorial_GameOver");
            }
        }

        // if conspiracy full
        if (PlayerController.playerInfo.conspiracy >= PlayerController.playerInfo.maxConspiracy)
        {
            if (SceneManager.GetActiveScene().name == "Gameplay")
            {
                Debug.Log("saving_FBIcaught");
                entryName = randomNames[Random.Range(0, randomNames.Count - 1)] + randomNames[Random.Range(0, randomNames.Count - 1)];
                /*AddScore.addScore.AddNewScore(names[AlienNames.alienNames.alienNameIndex],
                                              PlayerController.playerInfo.cowCount); */
                AddScore.addScore.AddNewScore(entryName,
                                              PlayerController.playerInfo.cowCount);
                //AlienNames.alienNames.alienNameIndex++;
                SceneManager.LoadScene("GameOver_FBI_Cutscene");
                Debug.Log("done saving");
            }
            if (SceneManager.GetActiveScene().name == "Tutorial_game")
            {
                SceneManager.LoadScene("Tutorial_GameOver");
            }
        }
    }
}
