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

    // tutorial text
    public GameObject movementText;
    public GameObject collectCowsText;
    public GameObject cowDroughtText;
    public GameObject FBI_text;
    public GameObject obstacle_text;

    public GameObject readyToPlayPanel;

    public float textTimer;

    void Start()
    {
        timeBetweenSpawn_blocks = 6.5f;
        blocksSpawned = 0; 
        currentBlock = tutorialList[0]; // start with movement
        InvokeRepeating("SpawnBlocks", 0f, timeBetweenSpawn_blocks);

        // tutorial text
        movementText.SetActive(true);
        collectCowsText.SetActive(false);
        cowDroughtText.SetActive(false);
        FBI_text.SetActive(false);
        obstacle_text.SetActive(false);

        readyToPlayPanel.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(timeBetweenSpawn_blocks);

        // next collect cows
        if (blocksSpawned >= 0 && blocksSpawned <= 1)
        {
            currentBlock = tutorialList[1];
            
        }

        // next cow drought
        if (blocksSpawned > 2 && blocksSpawned <= 4)
        {
            currentBlock = tutorialList[2];
            movementText.SetActive(false);
            collectCowsText.SetActive(true);
            
        }

        // next fbi
        if (blocksSpawned > 4 && blocksSpawned <= 6)
        {
            currentBlock = tutorialList[3];
            collectCowsText.SetActive(false);
            cowDroughtText.SetActive(true);
            
        }

        // next dodge obstacles
        if (blocksSpawned > 6 && blocksSpawned <= 8)
        {
            currentBlock = tutorialList[4];
            cowDroughtText.SetActive(false);
            FBI_text.SetActive(true);
            
        }

        // next empty field, ask to repeat tutorial or play game

        if (blocksSpawned > 8)
        {
            currentBlock = tutorialList[5];
            FBI_text.SetActive(false);
            obstacle_text.SetActive(true);
        }

        if (blocksSpawned > 9)
        {
            obstacle_text.SetActive(false);
            readyToPlayPanel.SetActive(true);
            Time.timeScale = 0;
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
