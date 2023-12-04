using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehavior : MonoBehaviour
{
    public GameVFX gameVFX;

    private GameObject player;
    private bool _cowInBeam;
    public float happinessValue;

    //public SpriteRenderer cowRenderer;

    private GameObject cowSFX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cowSFX = GameObject.Find("AudioSource_cow");

        gameVFX = player.GetComponent<GameVFX>();
    }

    private void Update()
    {
        // collect cow
        if (_cowInBeam)
        {
            // enable outlined cow indicator sprite

            // BOTH buttons to collect
            if (PlayerController.playerInfo.collectionControls._beamOn)
            {

                //if (Input.GetKeyDown(KeyCode.Backslash))
                if (PlayerController.playerInfo.collectionControls._collect)
                {
                   
                    //cowSFX.GetComponent<AudioSource>().pitch = Random.Range(0, 1);
                    cowSFX.GetComponent<AudioSource>().Play();

                    gameVFX.gotCow = true;

                    // stats
                    PlayerController.playerInfo.cowCount++;
                    PlayerController.playerInfo.happiness += happinessValue; // add 1 to happiness

                    PlayerController.playerInfo.timeWithoutCowCollected = 0f; // reset timer
                    PlayerController.playerInfo.inCowDrought = false;

                    Destroy(this.gameObject);
                }

            }
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
