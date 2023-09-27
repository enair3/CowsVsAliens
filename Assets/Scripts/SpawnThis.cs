using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThis : MonoBehaviour
{
    public GameObject[] animals; // list of objects to spawn
    private List<GameObject> spawnedObjects = new List<GameObject>(); // keep track of what's spawned
    // insert spawn obstacles later

    //spawn parameters
    [SerializeField] private float minX, maxX;
    [SerializeField] private float timeBetweenSpawn;

    //private float spawnTime;

    void Start()
    {
        InvokeRepeating("SpawnAnimals", 0f, timeBetweenSpawn);
    }

    void SpawnAnimals()
    {
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn);
        // spawn within range
        float randomX = Random.Range(minX, maxX);

        GameObject prefab = animals[Random.Range(0, animals.Length)];
        GameObject clone = Instantiate(prefab, transform.position + 
            new Vector3(randomX, 5, 0), 
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
    }
}
