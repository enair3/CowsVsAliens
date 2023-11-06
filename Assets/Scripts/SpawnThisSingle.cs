using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThisSingle : MonoBehaviour
{
    private List<GameObject> spawnedObjects = new List<GameObject>(); // keep track of what's spawned
    [SerializeField] private float timeBetweenSpawn_blocks = 3f;

    // spawning vars
    public int mode;
    public int blocksSpawned;

    // BLOCKS to spawn
    //public GameObject[] blocks;
    public GameObject[] activeList;
    public GameObject[] easy;
    public GameObject[] med;
    public GameObject[] hard;

    void Start()
    {
        mode = 1;
        blocksSpawned = 0;
        activeList = easy;
        InvokeRepeating("SpawnBlocks", 0f, timeBetweenSpawn_blocks);
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
    }

}
