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
        if (PlayerControllerDEMO.playerInfo.happiness <= 0 || PlayerControllerDEMO.playerInfo.conspiracy >= 10)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
