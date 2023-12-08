using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBIBehavior : MonoBehaviour
{
    public GameVFX gameVFX;

    private GameObject player;
    private bool _fbiInBeam;
    [SerializeField] private float timeDetectedByFBI;

    public SpriteRenderer fbiRenderer;
    public GameObject fbiHighlight;
    public Sprite fbiGone;

    private GameObject fbiSFX;
    private GameObject fbiYell;
    public AudioClip[] fbiYellClip;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        fbiSFX = GameObject.Find("AudioSource_fbi");
        fbiYell = GameObject.Find("AudioSource_fbiYell");
        fbiYell.GetComponent<AudioSource>().Stop();

        gameVFX = player.GetComponent<GameVFX>();
        fbiHighlight.SetActive(false);

        timeDetectedByFBI = 0f;  
    }

    private void Update()
    {
        // FBI detection
        if (_fbiInBeam)
        {
            // level 1 severity: hover over FBI, NO BUTTONS PRESSED
            // if beam is off
            PlayerController.playerInfo.conspiracy += 0.6f * timeDetectedByFBI;

            fbiHighlight.SetActive(true);

            // level 2 severity: hover over FBI with beam on, 1 BUTTON PRESSED (\)
            // if beam is on
            if (PlayerController.playerInfo.collectionControls._beamOn)
            {
                PlayerController.playerInfo.conspiracy += 0.8f * timeDetectedByFBI;

                // level 3 severity: pick up FBI and NOT hiding FBI nor satellite, BOTH BUTTONS PRESSED (\ AND Space)
                if (this.gameObject.tag == "FBI" && PlayerController.playerInfo.collectionControls._collect)
                {
                    fbiSFX.GetComponent<AudioSource>().Play();

                    gameVFX.gotFBI = true;

                    Debug.Log("got fbi");
                    PlayerController.playerInfo.conspiracy++; // add 1 to conspiracy
                    PlayerController.playerInfo.cowCount--; // subtract 1 cow

                    Destroy(this.gameObject);
                    //fbiRenderer.enabled = false;
                    //this.GetComponent<Collider2D>().enabled = false;
                }

                if (this.gameObject.tag == "HidingFBI" && PlayerController.playerInfo.collectionControls._collect)
                {
                    fbiSFX.GetComponent<AudioSource>().Play();

                    gameVFX.gotFBI = true;

                    Debug.Log("got fbi");
                    PlayerController.playerInfo.conspiracy++; // add 1 to conspiracy
                    PlayerController.playerInfo.cowCount--; // subtract 1 cow

                    // change to no more FBI upon pickup (visual and no collider interactions), now acts as decor
                    fbiRenderer.sprite = fbiGone;
                    GetComponent<Collider2D>().enabled = false;
                }
            }
        }

        if (!_fbiInBeam)
        {
            timeDetectedByFBI = 0f;

            fbiHighlight.SetActive(false);
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

                fbiYell.GetComponent<AudioSource>().clip = fbiYellClip[Random.Range(0, 3)];
                fbiYell.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
                fbiYell.GetComponent<AudioSource>().Play();

                gameVFX.conspiracyUp.SetActive(true);
            }
        }

        if (this.GetComponent<Collider2D>().enabled == false)
        {
            if (collision.tag == "Player")
            {
                //Debug.Log("player fbi collision");
                _fbiInBeam = false;
                timeDetectedByFBI += 0; // stop timer

                fbiYell.GetComponent<AudioSource>().Stop();

                gameVFX.conspiracyUp.SetActive(false);
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

                fbiYell.GetComponent<AudioSource>().Stop();

                gameVFX.conspiracyUp.SetActive(false);
            }
        }

        if (this.GetComponent<Collider2D>().enabled == false)
        {
            if (collision.tag == "Player")
            {
                //Debug.Log("player fbi collision");
                _fbiInBeam = false;
                timeDetectedByFBI += 0; // stop timer

                fbiYell.GetComponent<AudioSource>().Stop();

                gameVFX.conspiracyUp.SetActive(false);
            }
        }
    }
}
