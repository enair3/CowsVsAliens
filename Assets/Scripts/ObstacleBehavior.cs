using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.audioManager.sfx.clip = AudioManager.audioManager.sfxClips[4];
            AudioManager.audioManager.sfx.Play();
            // add delay

            BCollect_PlayerController.playerInfo.happiness = 0;
            BCollect_PlayerController.playerInfo.conspiracy = 0;

        }
    }
}
