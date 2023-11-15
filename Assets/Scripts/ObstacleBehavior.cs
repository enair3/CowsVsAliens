using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private GameObject obsSFX;

    private void Start()
    {
        obsSFX = GameObject.Find("AudioSource_obs");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //obsSFX.GetComponent<AudioSource>().PlayOneShot(obsSFX.GetComponent<AudioSource>().clip);
            obsSFX.GetComponent<AudioSource>().Play();
            PlayerController.playerInfo.playerParticles[2].Play();

            PlayerController.playerInfo.happiness -= 1;
            PlayerController.playerInfo.cowCount -= 1;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.playerInfo.playerParticles[2].Stop();
        }
    }
}
