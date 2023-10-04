using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.audioManager.sfx.clip = AudioManager.audioManager.sfxClips[3];
            AudioManager.audioManager.sfx.Play();

            PlayerControllerDEMO.playerInfo.happiness = 0;
            PlayerControllerDEMO.playerInfo.conspiracy = 0;

        }
    }
}
