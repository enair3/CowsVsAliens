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
    }

    // Update is called once per frame
    void Update()
    {
        // if happiness empty
        if (PlayerController.playerInfo.happiness <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Gameplay" )
            {

                //XMLManager.instance.SaveScores();
                //AddScore.addScore.AddNewScore("name", 6);
                //XMLManager.instance.Save();
                Debug.Log("saving_noCowEnd");
                AddScore.addScore.AddNewScore("name", PlayerController.playerInfo.cowCount);
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
                AddScore.addScore.AddNewScore("name", PlayerController.playerInfo.cowCount);
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
