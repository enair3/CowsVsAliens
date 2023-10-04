using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThis : MonoBehaviour
{
    // categories, lists of objects to spawn
    // interactables
    public GameObject[] cows;
    public GameObject[] fbi;
    public GameObject[] obstacles;

    // non-interactables
    public GameObject[] backgrounds;
    public GameObject[] decor;

    private List<GameObject> spawnedObjects = new List<GameObject>(); // keep track of what's spawned

    // spawn parameters
    [SerializeField] private float minX, maxX;

    // may need to randomize time spawning within a range
    [SerializeField] private float timeBetweenSpawn_cow;
    [SerializeField] private float timeBetweenSpawn_fbi;
    [SerializeField] private float timeBetweenSpawn_obstacles;

    [SerializeField] private float timeBetweenSpawn_backgrounds;
    [SerializeField] private float timeBetweenSpawn_decor;

    void Start()
    {
        InvokeRepeating("SpawnCows", 0f, timeBetweenSpawn_cow);
        InvokeRepeating("SpawnFBI", 0f, timeBetweenSpawn_fbi);
        InvokeRepeating("SpawnObstacles", 0f, timeBetweenSpawn_obstacles);

        InvokeRepeating("SpawnBackgrounds", 0f, timeBetweenSpawn_backgrounds);
        InvokeRepeating("SpawnDecor", 0f, timeBetweenSpawn_decor);
    }

    // spawn cows
    void SpawnCows()
    {
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_cow);
        // spawn within range
        float randomX = Random.Range(minX, maxX);

        GameObject prefab = cows[Random.Range(0, cows.Length)]; // will need to revise to include order
        GameObject clone = Instantiate(prefab, transform.position +
            new Vector3(randomX, 5, 0),
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
    }

    void SpawnFBI()
    {
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_fbi);
        // spawn within range
        float randomX = Random.Range(minX, maxX);

        GameObject prefab = fbi[Random.Range(0, fbi.Length)];
        GameObject clone = Instantiate(prefab, transform.position +
            new Vector3(randomX, 5, 0),
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
    }

    void SpawnObstacles()
    {
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_fbi);
        // spawn within range
        float randomX = Random.Range(minX, maxX);

        GameObject prefab = obstacles[Random.Range(0, obstacles.Length)];
        GameObject clone = Instantiate(prefab, transform.position +
            new Vector3(randomX, 5, 0),
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
    }

    void SpawnBackgrounds()
    {
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_backgrounds);

        GameObject prefab = backgrounds[Random.Range(0, backgrounds.Length)];
        GameObject clone = Instantiate(prefab, transform.position +
            new Vector3(0, 5, 0), // constant spawn point
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
    }

    void SpawnDecor()
    {
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_fbi);
        // spawn within range
        float randomX = Random.Range(minX, maxX);

        GameObject prefab = decor[Random.Range(0, decor.Length)];
        GameObject clone = Instantiate(prefab, transform.position +
            new Vector3(randomX, 5, 0),
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);
    }
}
