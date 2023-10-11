using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagement : MonoBehaviour
{
    // prefab buttons
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Title");
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
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1;
    }

    public void HowToPlay() // likely expand to multiple parts
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
