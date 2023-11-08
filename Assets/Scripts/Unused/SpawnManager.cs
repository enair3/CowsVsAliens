using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnManager;

    // spawning vars
    public int totalBlocks;

    private SpawnThisSingle spawnThisSingle;
    private SpawnThisDouble spawnThisDouble;

    public bool singleOn;
    public bool doubleOn;


    // Start is called before the first frame update
    void Start()
    {
        spawnThisSingle = GetComponent<SpawnThisSingle>();
        spawnThisDouble = GetComponent<SpawnThisDouble>();

        spawnThisSingle.enabled = true;
        spawnThisDouble.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (singleOn)
        {
            spawnThisSingle.enabled = true;
            spawnThisDouble.enabled = false;
        }

        if (doubleOn)
        {
            spawnThisSingle.enabled = false;
            spawnThisDouble.enabled = true;
        }
    }
}
