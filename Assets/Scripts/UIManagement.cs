using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagement : MonoBehaviour
{
    // prefab buttons

    public float delay = 0.2f;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;
    }

    public void Back() // for how to play
    {
        
    }

    public void Next() // for how to play
    {

    }

    // menu buttons
    public void PlayGame() // use for menu "play", pause panel "restart", game over "play again", just change text
    {
        //Invoke("Gameplay", delay);
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1;

    }
    
    // Christine: button goes to intro cutscene
    public void IntroCutscene()
    {
        SceneManager.LoadScene("IntroCutscene");
        Time.timeScale = 1;
    }
	
	// Christine: button goes to Game Over Scene
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 1;
    }

    public void TutorialGame() // use for menu "play", pause panel "restart", game over "play again", just change text
    {
        //Invoke("Tutorial_game", delay);
        SceneManager.LoadScene("Tutorial_game");
        Time.timeScale = 1;
    }

    public void HowToPlay() // likely expand to multiple parts
    {
        SceneManager.LoadScene("HowToPlay");
        Time.timeScale = 1;
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
        Time.timeScale = 1;
    }

    public void TESTLeaderboard()
    {
        SceneManager.LoadScene("TestingLeaderboard");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
