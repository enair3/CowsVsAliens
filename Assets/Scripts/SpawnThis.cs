using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnThis : MonoBehaviour
{
    private List<GameObject> spawnedObjects = new List<GameObject>(); // keep track of what's spawned
    //public int mode;
    //public int blocksSpawned;

    // BLOCKS to spawn
    public GameObject[] blocks;
    /*public GameObject[] activeList;
    public GameObject[] easy;
    public GameObject[] med;
    public GameObject[] hard;*/

    //public GameObject prefab;
    //public GameObject clone;

    //public WaitForSeconds resetTime;

    //public List<List<GameObject>> Meadow_easy = new List<List<GameObject>>();

    [SerializeField] private float timeBetweenSpawn_blocks = 3f;

    void Start()
    {
        //mode = 1;
        //blocksSpawned = 0;
        //activeList = easy;
        InvokeRepeating("SpawnBlocks", 0f, timeBetweenSpawn_blocks);
    }

    /*private void Update()
    {
        if (blocksSpawned > 5 && blocksSpawned <= 10)
        {
            activeList = med;
        }
            
        if (blocksSpawned > 10)
        {
            activeList = hard;
        }
    }*/

    // level design block spawning
    void SpawnBlocks()
    {
        
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_blocks);
        GameObject prefab = blocks[Random.Range(0, blocks.Length)]; // will need to revise to include order
        GameObject clone = Instantiate(prefab, transform.position,
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
        //blocksSpawned++;

        //GameObject prefab = Easy[]

        /*if (blocksSpawned <= 5)
        {
            //WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_blocks);
            //resetTime = new WaitForSeconds(timeBetweenSpawn_blocks);
            //yield return new WaitForSeconds(timeBetweenSpawn_blocks);
            mode = 1;
            
            prefab = easy[Random.Range(0, easy.Length)]; // will need to revise to include order
            //clone = Instantiate(prefab, transform.position,
            //transform.rotation);

            blocksSpawned++;
            Debug.Log(timeBetweenSpawn_blocks + " mode 1");
            //spawnedObjects.Add(clone);
        }

        if (blocksSpawned > 5 && blocksSpawned <= 10)
        {
            //WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_blocks);
            //yield return new WaitForSeconds(timeBetweenSpawn_blocks);
            mode = 2;

            prefab = med[Random.Range(0, med.Length)]; // will need to revise to include order
            //clone = Instantiate(prefab, transform.position,
            //    transform.rotation);

            blocksSpawned++;
            Debug.Log(timeBetweenSpawn_blocks + " mode 2");
            //spawnedObjects.Add(clone);
        }

        if (blocksSpawned > 10)
        {
            //WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_blocks);
            //yield return new WaitForSeconds(timeBetweenSpawn_blocks);
            mode = 3;

            prefab = hard[Random.Range(0, hard.Length)]; // will need to revise to include order
            //clone = Instantiate(prefab, transform.position,
            //    transform.rotation);

            blocksSpawned++;
            Debug.Log(timeBetweenSpawn_blocks + " mode 3");
            //spawnedObjects.Add(clone);
        }
        */
        
    }

    // determine time for next spawn using prev block tag/length
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "1Xblock")
        {
            timeBetweenSpawn_blocks = 3f;
        }
        if (collision.tag == "2Xblock")
        {
            timeBetweenSpawn_blocks = 6f;
        }
    }
}
