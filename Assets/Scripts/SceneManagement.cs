using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement scenes;
    //public PlayerControllerDEMO player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerDEMO.player.happiness <= 0 || PlayerControllerDEMO.player.conspiracy >= 10)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
