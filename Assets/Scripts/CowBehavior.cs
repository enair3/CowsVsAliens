using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehavior : MonoBehaviour
{
    public PlayerControllerDEMO playerBehavior;
    private GameObject player;
    private bool _cowInBeam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_cowInBeam)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("got cow");
                playerBehavior.cowCount++; // add 1 to cowCount
                playerBehavior.happiness++; // add 1 to happiness
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
            //Debug.Log("player cow collision");
            _cowInBeam = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            _cowInBeam = false; // reset bool
        }
    }
}
