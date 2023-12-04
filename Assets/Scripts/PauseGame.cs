using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static PauseGame pauseGame;
    public GameObject pauseGamePanel;
    public GameObject[] panelButtons;

    private void Start()
    {
        pauseGamePanel.SetActive(false);
        /*foreach (var btn in panelButtons)
        {
            btn.SetActive(false);
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(DelayShow());
        ActivatePause();
    }

    void ActivatePause()
    {
        
        
        if (Input.GetKey(KeyCode.Escape))
        {
            //Invoke("ActivatePause", 2f);
            //StartCoroutine(DelayShow());
            pauseGamePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ContinuePlaying()
    {
        pauseGamePanel.SetActive(false);
        Time.timeScale = 1;
    }

    //add delay activate
    /*
    public void AssetCredits()
    {
        StartCoroutine(DelayShow());
        creds.SetActive(true);
        //thisButton.enabled = true;
    }*/

    IEnumerator DelayShow() //won't show bc timescale = 0 when panel is on, waitforseconds doesn't go. need to fix
    {
       yield return new WaitForSeconds(1f);
       foreach (var btn in panelButtons)
       {
            btn.SetActive(true);
       }
   
    }
}
