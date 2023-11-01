using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehavior : MonoBehaviour
{
    private GameObject player;
    private bool _cowInBeam;
    public float happinessValue;
    public Sprite greenBeam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        // collect cow
        if (_cowInBeam)
        {
            // enable outlined cow indicator sprite

            // BOTH buttons to collect
            if (BCollect_PlayerController.playerInfo._beamOn)
            {
                //AudioManager.audioManager.sfx.clip = AudioManager.audioManager.sfxClips[1];
                //AudioManager.audioManager.sfx.Play();

                if (Input.GetKeyDown(KeyCode.Backslash))
                {
                    // collection visuals - REVISIT
                    //PlayerControllerDEMO.playerInfo.beamRenderer.sprite = greenBeam;

                    //Debug.Log("got cow");

                    AudioManager.audioManager.sfx.clip = AudioManager.audioManager.sfxClips[3]; //switch to alternating sfx
                    AudioManager.audioManager.sfx.Play();

                    BCollect_PlayerController.playerInfo.cowCount++; // add 1 to cowCount. NEED TO ADAPT TO GETCOMPONENT FOR SPECIAL COW
                    BCollect_PlayerController.playerInfo.happiness += happinessValue; // add 1 to happiness

                    BCollect_PlayerController.playerInfo.timeWithoutCowCollected = 0f; // reset timer
                    BCollect_PlayerController.playerInfo.inCowDrought = false;

                    Destroy(this.gameObject);
                }

            }
        } 

        // cow drought penalty
        if (BCollect_PlayerController.playerInfo.timeWithoutCowCollected >= 8.0f)
        {
            BCollect_PlayerController.playerInfo.inCowDrought = true;
            CowDroughtPenalty();
            // decrease happiness by value per time in drought, not incl threshold
            //PlayerControllerDEMO.playerInfo.happiness -= (0.2f * (timeWithoutCowCollected - 8.0f)); 
        }

    }

    // need to recheck this
    void CowDroughtPenalty()
    {
        if (BCollect_PlayerController.playerInfo.inCowDrought)
        {
            BCollect_PlayerController.playerInfo.happiness -= (0.0001f * (BCollect_PlayerController.playerInfo.timeWithoutCowCollected - 8.0f));
        } else {
            BCollect_PlayerController.playerInfo.timeWithoutCowCollected = 0f;
        }
        
    }

    // hi cow
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            //Debug.Log("player cow collision");
            _cowInBeam = true;
        }
    }

    // bye cow
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            _cowInBeam = false; // reset bool
        }
    }
}
