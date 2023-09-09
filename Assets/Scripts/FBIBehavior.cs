using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBIBehavior : MonoBehaviour
{
    public PlayerControllerDEMO playerBehavior;
    private GameObject player;
    private bool _fbiInBeam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_fbiInBeam)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("got fbi");
                playerBehavior.conspiracy++; // add 1 to conspiracy
                Destroy(this.gameObject);
            }
        }
    }

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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            _fbiInBeam = false; // reset bool
        }
    }
}
