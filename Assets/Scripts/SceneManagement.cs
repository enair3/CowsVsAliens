using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement sceneManager;


    private void Awake()
    {
        sceneManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        // if happiness empty
        if (PlayerController.playerInfo.happiness <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Gameplay" )
            {
                SceneManager.LoadScene("GameOver_noCow_Cutscene");
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
                SceneManager.LoadScene("GameOver_FBI_Cutscene");
            }
            if (SceneManager.GetActiveScene().name == "Tutorial_game")
            {
                SceneManager.LoadScene("Tutorial_GameOver");
            }
        }
    }
}
