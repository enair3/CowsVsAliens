using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCow : MonoBehaviour
{
    public GameObject[] cowOptions;

    // Start is called before the first frame update
    void Start()
    {
        /*cowOptions[0] = Resources.Load("CowStanding") as GameObject;
        cowOptions[1] = Resources.Load("CowSleeping") as GameObject;
        cowOptions[2] = Resources.Load("CowEating") as GameObject;*/

        int thisCow = Random.Range(0, 3);
        cowOptions[thisCow].SetActive(true);
        //Instantiate(cowOptions[thisCow], transform.position, transform.rotation);
    }
}
