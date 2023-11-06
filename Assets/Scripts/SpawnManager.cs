using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnManager;

    // spawning vars
    public int mode;
    public int blocksSpawned;

    public bool singleOn;
    public bool doubleOff;


    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<SpawnThisSingle>.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
