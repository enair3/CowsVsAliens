using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionControls : MonoBehaviour
{
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
        _beamOn = false;
        _collect = false;

        beamRenderer.sprite = neutralBeam;
        beamRenderer.enabled = false; // start beam off

        beamSFX = GameObject.Find("AudioSource_beam");
    }

    // A collection scheme. whoever presses button first is beam, second press is collect (Space and \ in no specific order, role)
    /*void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Backslash)) //beam
        {
            //Debug.Log("beam on");
            _beamOn = true;

            if (Input.GetKey(KeyCode.Space)) //collect
            {
                if (Input.GetKeyDown(KeyCode.Backslash))
                {
                    //Debug.Log("collect");
                    _collect = true;
                }

                if (!Input.GetKeyDown(KeyCode.Backslash))
                {
                    //Debug.Log("collect");
                    _collect = false;
                }
            }

            if (Input.GetKey(KeyCode.Backslash)) //collect
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Debug.Log("collect");
                    _collect = true;
                }

                if (!Input.GetKeyDown(KeyCode.Space))
                {
                    //Debug.Log("collect");
                    _collect = false;
                }
            }
        }

        if (!Input.GetKey(KeyCode.Space) || !Input.GetKey(KeyCode.Backslash))
        {
            //Debug.Log("beam, collect off");
            _beamOn = false;
            _collect = false;
        }

        BeamTriggers();
    }*/

    // B collection scheme. set roles. P1 = beam Space, P2 = collect \
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //beam
        {
            //Debug.Log("beam on");
            _beamOn = true;

            if (Input.GetKeyDown(KeyCode.Backslash)) //collect
            {
                //Debug.Log("collect");
                _collect = true;
            }

            if (!Input.GetKeyDown(KeyCode.Backslash)) //collect
            {
                _collect = false;
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
                beamRenderer.sprite = greenBeam; // trouble figuring out how to make it stay for 1sec
            }

            if (!_collect)
            {
                beamRenderer.sprite = neutralBeam;
            }
        }

        if (!_beamOn)
        {
            beamRenderer.sprite = neutralBeam;
            beamRenderer.enabled = false;
        }
    }
}
