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
    public GameObject[] tutorialText;
    public GameObject currentBlock;

    // tutorial text
    /*public GameObject movementText;
    public GameObject collectCowsText;
    public GameObject cowDroughtText;
    public GameObject FBI_text;
    public GameObject obstacle_text;*/

    public GameObject activeText;

    public GameObject readyToPlayPanel;

    //public float textTimer;

    void Start()
    {
        timeBetweenSpawn_blocks = 6.5f;
        blocksSpawned = 0; 
        currentBlock = tutorialList[0]; // start with movement
        InvokeRepeating("SpawnBlocks", 0f, timeBetweenSpawn_blocks);

        // tutorial text
        /*movementText.SetActive(true);
        collectCowsText.SetActive(false);
        cowDroughtText.SetActive(false);
        FBI_text.SetActive(false);
        obstacle_text.SetActive(false);*/
        //activeText.SetActive(true);
        activeText = tutorialText[0];
        activeText.SetActive(true);

        readyToPlayPanel.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(timeBetweenSpawn_blocks);

        // next collect cows
        if (blocksSpawned == 1)
        {
            activeText.SetActive(false);
            currentBlock = tutorialList[1];
            activeText = tutorialText[1];
            activeText.SetActive(true);
            //activeText.SetActive(true);

        }

        // next cow drought
        if (blocksSpawned >= 2 && blocksSpawned <= 4)
        {
            currentBlock = tutorialList[2];
            activeText = tutorialText[2];
            /*movementText.SetActive(false);
            collectCowsText.SetActive(true);*/

        }

        // next fbi
        if (blocksSpawned > 4 && blocksSpawned <= 6)
        {
            currentBlock = tutorialList[3];
            activeText = tutorialText[3];
            /*collectCowsText.SetActive(false);
            cowDroughtText.SetActive(true);*/

        }

        // next dodge obstacles
        if (blocksSpawned > 6 && blocksSpawned <= 8)
        {
            currentBlock = tutorialList[4];
            activeText = tutorialText[4];
            /*cowDroughtText.SetActive(false);
            FBI_text.SetActive(true);*/

        }

        // next empty field, ask to repeat tutorial or play game
        if (blocksSpawned > 9)
        {
            //obstacle_text.SetActive(false);
            readyToPlayPanel.SetActive(true);
            activeText.SetActive(false);
            Time.timeScale = 0;
        }

       //if pause panel activated, disable activeText
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
