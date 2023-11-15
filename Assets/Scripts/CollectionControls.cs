using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionControls : MonoBehaviour
{
    // tap vars
    public float holdBeam = 0.5f;
    float beamTimer;

    // collection controls vars
    public bool _beamOn;
    public bool _collect;

    // beam vars
    public SpriteRenderer beamRenderer;
    public Sprite neutralBeam;
    public Sprite greenBeam;

    private GameObject beamSFX;

    // Start is called before the first frame update
    void Start()
    {
        beamTimer = holdBeam;

        _beamOn = false;
        _collect = false;

        beamRenderer.sprite = neutralBeam;
        beamRenderer.enabled = false; // start beam off

        beamSFX = GameObject.Find("AudioSource_beam");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //beam
        {
            //Debug.Log("beam on");
            _beamOn = true;

            if (Input.GetKey(KeyCode.Backslash)) //collect
            {
                //Debug.Log("collect")
                _collect = true;

                beamTimer -= Time.deltaTime;
                if (beamTimer < 0)
                {
                    _collect = false;
                }
            }

            if (!Input.GetKey(KeyCode.Backslash)) //collect
            {
                _collect = false;
                beamTimer = holdBeam;
            }
        }

        if (!Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("beam, collect off");
            _beamOn = false;
            _collect = false;
        }

        BeamTriggers();
    }

    // beam
    void BeamTriggers()
    {
        // beam triggers audio and sprite
        if (_beamOn)
        {
            // audio
            //AudioManager.audioManager.sfx.loop = true;

            //beamSFX.GetComponent<AudioSource>().PlayOneShot(beamSFX.GetComponent<AudioSource>().clip);
            beamSFX.GetComponent<AudioSource>().Play();

            // sprite
            beamRenderer.enabled = true;

            if (_collect)
            {
                beamRenderer.sprite = greenBeam;
            }

            if (!_collect)
            {
                beamRenderer.sprite = neutralBeam;
                PlayerController.playerInfo.playerParticles[0].Stop();
                PlayerController.playerInfo.playerParticles[1].Stop();
            }
        }

        if (!_beamOn)
        {
            beamRenderer.sprite = neutralBeam;
            beamRenderer.enabled = false;
        }
    }
}
