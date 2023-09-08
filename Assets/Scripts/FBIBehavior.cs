using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBIBehavior : MonoBehaviour
{
    public PlayerControllerDEMO playerBehavior;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "bottomBorder")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Player")
        {
            Debug.Log("player fbi collision");
            if (Input.GetKeyDown(KeyCode.Space)) //can turn to && later
            {
                Debug.Log("got fbi");
                playerBehavior.conspiracy++; // add 1 to conspiracy
                Destroy(this.gameObject);
            }
        }
    }
}
