using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehavior : MonoBehaviour
{
    private GameObject player;
    private bool _cowInBeam;
    public float happinessValue;
    //[SerializeField] private float timeWithoutCowCollected;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        // collect cow
        if (_cowInBeam)
        {
            // change to outlined cow indicator sprite

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("got cow");
                PlayerControllerDEMO.playerInfo.cowCount++; // add 1 to cowCount. NEED TO ADAPT TO GETCOMPONENT FOR SPECIAL COW
                PlayerControllerDEMO.playerInfo.happiness+= happinessValue; // add 1 to happiness

                PlayerControllerDEMO.playerInfo.timeWithoutCowCollected = 0f; // reset timer
                PlayerControllerDEMO.playerInfo.inCowDrought = false;

                Destroy(this.gameObject);
            }
        }

        // cow drought penalty
        if (PlayerControllerDEMO.playerInfo.timeWithoutCowCollected >= 8.0f)
        {
            PlayerControllerDEMO.playerInfo.inCowDrought = true;
            CowDroughtPenalty();
            // decrease happiness by value per time in drought, not incl threshold
            //PlayerControllerDEMO.playerInfo.happiness -= (0.2f * (timeWithoutCowCollected - 8.0f)); 
        }

    }

    // need to recheck this
    void CowDroughtPenalty()
    {
        if (PlayerControllerDEMO.playerInfo.inCowDrought)
            PlayerControllerDEMO.playerInfo.happiness -= (0.0001f * (PlayerControllerDEMO.playerInfo.timeWithoutCowCollected - 8.0f));
        else
            PlayerControllerDEMO.playerInfo.timeWithoutCowCollected = 0f;
        
    }

    // hi cow
    private void OnTriggerEnter2D(Collider2D collision)
    {

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
