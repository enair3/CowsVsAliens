using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBIBehavior : MonoBehaviour
{
    private GameObject player;
    private bool _fbiInBeam;
    [SerializeField] private float timeDetectedByFBI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeDetectedByFBI = 0f;
    }

    private void Update()
    {
        // FBI detection
        if (_fbiInBeam)
        {
            // level 1 severity: hover over FBI, NO BUTTONS PRESSED
            // if beam is off
            // PlayerControllerDEMO.playerInfo.conspiracy += 0.02f * timeDetectedByFBI;

            // level 2 severity: hover over FBI with beam on, 1 BUTTON PRESSED
            // if beam is on
            PlayerControllerDEMO.playerInfo.conspiracy += 0.04f * timeDetectedByFBI;

            // level 3 severity: pick up FBI, BOTH BUTTONS PRESSED
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("got fbi");
                PlayerControllerDEMO.playerInfo.conspiracy++; // add 1 to conspiracy
                PlayerControllerDEMO.playerInfo.cowCount--; // subtract 1 cow
                Destroy(this.gameObject);
            }
        }
    }

    // start fbi detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bottomBorder")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Player")
        {
            //Debug.Log("player fbi collision");
            _fbiInBeam = true;
            timeDetectedByFBI += Time.deltaTime; // start timer
        }
    }

    // end fbi detection
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            _fbiInBeam = false; // reset bool
            timeDetectedByFBI = 0f; // reset timer
        }
    }
}
