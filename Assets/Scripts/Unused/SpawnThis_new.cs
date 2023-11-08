using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThis_new : MonoBehaviour
{
    private List<GameObject> spawnedObjects = new List<GameObject>();

    public GameObject[] blocks;
    [SerializeField] private float timeBetweenSpawn_blocks = 3f;

    public IEnumerator spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSpawnTime());
        //StartSpawnCoroutine();
    }
    
    private IEnumerator ChangeSpawnTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn_blocks);

            SpawnBlocks();
        }
    }

    IEnumerator SpawnBlocksCoroutine(float timer)
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            SpawnBlocks();
        }
    }

    public void StartSpawnCoroutine()
    {
        //Moved the creation of the IEnumerable in to this function.
        spawnCoroutine = SpawnBlocksCoroutine(timeBetweenSpawn_blocks);
        StartCoroutine(spawnCoroutine);
    }
    /*public void StopSpawnCoroutine()
    {
        StopCoroutine(spawnCoroutine);
    }*/

    void SpawnBlocks()
    {
        
        //while (true)
        //{
            //yield return new WaitForSeconds(timeBetweenSpawn_blocks);
            GameObject prefab = blocks[Random.Range(0, blocks.Length)]; // will need to revise to include order
            GameObject clone = Instantiate(prefab, transform.position,
                transform.rotation);
            //yield return new WaitForSeconds(timeBetweenSpawn_blocks);
        //}
        
        
        /*WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_blocks);
        GameObject prefab = blocks[Random.Range(0, blocks.Length)]; // will need to revise to include order
        GameObject clone = Instantiate(prefab, transform.position,
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
        Debug.Log("spawned" + clone);
        Debug.Log(spawnedObjects.Count);*/
    }

    // determine time for next spawn using prev block tag/length
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "1Xblock")
        {
            timeBetweenSpawn_blocks = 3.2f;
        }
        if (collision.tag == "2Xblock")
        {
            timeBetweenSpawn_blocks = 6.2f;
        }
    }
}
