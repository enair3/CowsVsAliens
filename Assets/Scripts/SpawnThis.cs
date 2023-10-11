using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThis : MonoBehaviour
{
    private List<GameObject> spawnedObjects = new List<GameObject>(); // keep track of what's spawned

    // BLOCKS to spawn
    public GameObject[] blocks;
    [SerializeField] private float timeBetweenSpawn_blocks;

    void Start()
    {
        InvokeRepeating("SpawnBlocks", 0f, timeBetweenSpawn_blocks);
    }

    // level design block spawning
    void SpawnBlocks()
    {
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_blocks);
        GameObject prefab = blocks[Random.Range(0, blocks.Length)]; // will need to revise to include order
        GameObject clone = Instantiate(prefab, transform.position +
            new Vector3(0, 5, 0),
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
    }

}
