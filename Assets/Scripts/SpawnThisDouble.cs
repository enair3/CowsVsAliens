using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThisDouble : MonoBehaviour
{
    private List<GameObject> spawnedObjects = new List<GameObject>(); // keep track of what's spawned

    // spawning vars
    public int mode;
    public int blocksSpawned;
    [SerializeField] private float timeBetweenSpawn_blocks;

    // BLOCKS to spawn
    //public GameObject[] blocks;
    public GameObject[] activeList;
    public GameObject[] easy;
    public GameObject[] med;
    public GameObject[] hard;

    //public static List<GameObject[]> allBlocks;

    // class for difficulty to randomize between 2 or more difficulties

    public void Start()
    {
        timeBetweenSpawn_blocks = 6.5f;
        mode = 1;
        blocksSpawned = 0;
        activeList = easy;

        /*allBlocks.Add(easy);
        allBlocks.Add(med);
        allBlocks.Add(hard);

        Debug.Log(allBlocks);*/

        InvokeRepeating("SpawnBlocks", 0f, timeBetweenSpawn_blocks);
    }

    private void Update()
    {
        Debug.Log(timeBetweenSpawn_blocks);

        if (blocksSpawned > 10 && blocksSpawned <= 20)
        {
            activeList = med;
        }

        if (blocksSpawned > 20 && blocksSpawned <= 30)
        {
            activeList = hard;
        }

        if (blocksSpawned > 30)
        {
            activeList = hard;
        }
    }

    // level design block spawning
    void SpawnBlocks()
    {
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_blocks);
        GameObject prefab = activeList[Random.Range(0, activeList.Length)]; // will need to revise to include order
        GameObject clone = Instantiate(prefab, transform.position,
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
        blocksSpawned++;
    }

}
