using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehavior : MonoBehaviour
{
    //public PlayerControllerDEMO playerBehavior;
    private GameObject player;
    private bool _cowInBeam;
    [SerializeField] private float timeWithoutCowCollected;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeWithoutCowCollected = 0f;
        
    }

    private void Update()
    {
        timeWithoutCowCollected += Time.deltaTime; // timer between cow collections

        // collect cow
        if (_cowInBeam)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("got cow");
                PlayerControllerDEMO.playerInfo.cowCount++; // add 1 to cowCount. NEED TO ADAPT TO GETCOMPONENT FOR SPECIAL COW
                PlayerControllerDEMO.playerInfo.happiness++; // add 1 to happiness

                timeWithoutCowCollected = 0f; // reset timer

                Destroy(this.gameObject);
            }
        }

        // cow drought penalty
        if (timeWithoutCowCollected >= 8.0f)
        {
            // decrease happiness by value per time in drought, not incl threshold
            PlayerControllerDEMO.playerInfo.happiness -= (0.2f * (timeWithoutCowCollected - 8.0f)); 
        }

    }

    // hi cow
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

    // bye cow
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            _cowInBeam = false; // reset bool
        }
    }
}
