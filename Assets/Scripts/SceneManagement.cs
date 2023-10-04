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
        if (PlayerControllerDEMO.playerInfo.happiness <= 0 || PlayerControllerDEMO.playerInfo.conspiracy >= 10)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
