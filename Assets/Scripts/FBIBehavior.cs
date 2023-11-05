using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBIBehavior : MonoBehaviour
{
    private GameObject player;
    private bool _fbiInBeam;
    [SerializeField] private float timeDetectedByFBI;

    public SpriteRenderer fbiRenderer;
    public Sprite fbiGone;

    private GameObject fbiSFX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fbiSFX = GameObject.Find("AudioSource_fbi");
        timeDetectedByFBI = 0f;  
    }

    private void Update()
    {
        // FBI detection
        if (_fbiInBeam)
        {
            // level 1 severity: hover over FBI, NO BUTTONS PRESSED
            // if beam is off
            PlayerController.playerInfo.conspiracy += 0.02f * timeDetectedByFBI;
            PlayerController.playerInfo.conspiracy += 0.02f * timeDetectedByFBI;

            // level 2 severity: hover over FBI with beam on, 1 BUTTON PRESSED (\)
            // if beam is on
            if (PlayerController.playerInfo.collectionControls._beamOn)
            {
                PlayerController.playerInfo.conspiracy += 0.04f * timeDetectedByFBI;

                // level 3 severity: pick up FBI and NOT hiding FBI nor satellite, BOTH BUTTONS PRESSED (\ AND Space)
                if (this.gameObject.tag == "FBI" && PlayerController.playerInfo.collectionControls._collect)
                {
                    fbiSFX.GetComponent<AudioSource>().Play();

                    //Debug.Log("got fbi");
                    PlayerController.playerInfo.conspiracy++; // add 1 to conspiracy
                    PlayerController.playerInfo.cowCount--; // subtract 1 cow

                    Destroy(this.gameObject);
                    //fbiRenderer.enabled = false;
                    //this.GetComponent<Collider2D>().enabled = false;
                }

                if (this.gameObject.tag == "HidingFBI" && PlayerController.playerInfo.collectionControls._collect)
                {
                    //fbiSFX.GetComponent<AudioSource>().PlayOneShot(fbiSFX.GetComponent<AudioSource>().clip);
                    fbiSFX.GetComponent<AudioSource>().Play();

                    Debug.Log("got fbi");
                    PlayerController.playerInfo.conspiracy++; // add 1 to conspiracy
                    PlayerController.playerInfo.cowCount--; // subtract 1 cow

                    // change to no more FBI upon pickup (visual and no collider interactions), now acts as decor
                    fbiRenderer.sprite = fbiGone;
                    GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }

    // start fbi detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.GetComponent<Collider2D>().enabled == true)
        {
            if (collision.tag == "Player")
            {
                //Debug.Log("player fbi collision");
                _fbiInBeam = true;
                timeDetectedByFBI += Time.deltaTime; // start timer
            }
        }

        if (this.GetComponent<Collider2D>().enabled == false)
        {
            if (collision.tag == "Player")
            {
                //Debug.Log("player fbi collision");
                _fbiInBeam = false;
                timeDetectedByFBI += 0; // stop timer
            }
        }
    }

    // end fbi detection
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.GetComponent<Collider2D>().enabled == true)
        {
            if (collision.tag == "Player")
            {
                _fbiInBeam = false; // reset bool
                timeDetectedByFBI = 0f; // reset timer
            }
        }

        if (this.GetComponent<Collider2D>().enabled == false)
        {
            if (collision.tag == "Player")
            {
                //Debug.Log("player fbi collision");
                _fbiInBeam = false;
                timeDetectedByFBI += 0; // stop timer
            }
        }
    }
}
