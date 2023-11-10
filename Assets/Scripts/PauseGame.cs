using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static PauseGame pauseGame;
    public GameObject pauseGamePanel;

    private void Start()
    {
        pauseGamePanel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ActivatePause();
    }

    void ActivatePause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //Invoke("ActivatePause", 2f);
            pauseGamePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ContinuePlaying()
    {
        pauseGamePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
