using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public GameVFX gameVFX;
    private GameObject obsSFX;
    private GameObject player;

    private void Start()
    {
        obsSFX = GameObject.Find("AudioSource_obs");
        player = GameObject.FindGameObjectWithTag("Player");

        gameVFX = player.GetComponent<GameVFX>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            obsSFX.GetComponent<AudioSource>().Play();
            gameVFX.gotHit = true;

            PlayerController.playerInfo.happiness -= 1;
            PlayerController.playerInfo.cowCount -= 1;

        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            gameVFX.playerParticles[2].Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.playerInfo.playerParticles[2].Stop();
        }
    }*/
}
