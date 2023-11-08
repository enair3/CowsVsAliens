using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawnThisDouble : MonoBehaviour
{
    private List<GameObject> spawnedObjects = new List<GameObject>(); // keep track of what's spawned

    // spawning vars
    public int blocksSpawned;
    [SerializeField] private float timeBetweenSpawn_blocks;

    // BLOCKS to spawn
    //public GameObject[] blocks;
    public GameObject[] tutorialList;
    public GameObject currentBlock;

    void Start()
    {
        timeBetweenSpawn_blocks = 6.5f;
        blocksSpawned = 0; 
        currentBlock = tutorialList[0]; // start with movement
        InvokeRepeating("SpawnBlocks", 0f, timeBetweenSpawn_blocks);
    }

    private void Update()
    {
        Debug.Log(timeBetweenSpawn_blocks);

        // next collect cows
        if (blocksSpawned >= 0 && blocksSpawned <= 3)
        {
            currentBlock = tutorialList[1];
        }

        // next cow drought
        if (blocksSpawned > 3 && blocksSpawned <=4)
        {
            currentBlock = tutorialList[2];
        }

        // next fbi
        if (blocksSpawned > 4 && blocksSpawned <= 7)
        {
            currentBlock = tutorialList[3];
        }

        // next dodge obstacles
        if (blocksSpawned > 7 && blocksSpawned <= 9)
        {
            currentBlock = tutorialList[4];
        }

        // next empty field, ask to repeat tutorial or play game

        if (blocksSpawned > 9)
        {
            currentBlock = tutorialList[5];
        }
    }

    // level design block spawning
    void SpawnBlocks()
    {
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_blocks);
        GameObject prefab = currentBlock;
        GameObject clone = Instantiate(prefab, transform.position,
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
        blocksSpawned++;
    }

}
