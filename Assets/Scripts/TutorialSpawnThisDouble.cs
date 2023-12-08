using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSpawnThisDouble : MonoBehaviour
{
    private List<GameObject> spawnedObjects = new List<GameObject>(); // keep track of what's spawned

    // spawning vars
    public int blocksSpawned;
    [SerializeField] private float timeBetweenSpawn_blocks;

    // vars
    public GameObject readyToPlayPanel;
    public GameObject tutorialPausePanel;

    public float textTimer;

    // BLOCKS to spawn
    //public GameObject[] blocks;
    public GameObject[] tutorialList;
    public GameObject[] tutorialText;
    public GameObject currentBlock;

    // tutorial text
    public GameObject activeText;
    public GameObject toSkipText;

    public GameObject movementText;
    public GameObject collectCowsText;
    public GameObject cowDroughtText;
    public GameObject relieveDroughtText;
    public GameObject FBI_text;
    public GameObject obstacle_text;

    void Start()
    {
        timeBetweenSpawn_blocks = 6.5f;
        blocksSpawned = 0;
        textTimer= 0;
        currentBlock = tutorialList[0]; // start with movement
        InvokeRepeating("SpawnBlocks", 0f, timeBetweenSpawn_blocks);

        // tutorial text
        movementText.SetActive(true);
        collectCowsText.SetActive(false);
        cowDroughtText.SetActive(false);
        FBI_text.SetActive(false);
        obstacle_text.SetActive(false);

        activeText = movementText;
        toSkipText = GameObject.Find("PauseToSkip_text");
        toSkipText.SetActive(true);
    }

    private void Update()
    {
        textTimer += Time.deltaTime;
        PanelTextVisibility();
        TutorialBlocks();
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


    void PanelTextVisibility()
    {
        // if tutorial pause panel or ready to play activated, disable activeText and toSkipText
        //doesn't work now? but just moved order for quick fix, but can debug later
        if (tutorialPausePanel.activeSelf) 
        {
            activeText.SetActive(false);
            toSkipText.SetActive(false);
        }

        if (!tutorialPausePanel.activeSelf) 
        {
            activeText.SetActive(true);
            toSkipText.SetActive(true);
        }
    }

    // BLOCK & TEXT timing
    void TutorialBlocks()
    {
        if (!tutorialPausePanel.activeSelf)
        {
            // next collect cows
            if (blocksSpawned >= 1 && blocksSpawned <= 2)
            {
                currentBlock = tutorialList[1];
            }

            if (textTimer > 9f)
            {
                tutorialText[0].SetActive(false);
                collectCowsText.SetActive(true);
                activeText = collectCowsText;
            }

            // next cow drought
            if (blocksSpawned > 2 && blocksSpawned <= 4)
            {
                currentBlock = tutorialList[2];
            }

            if (textTimer > 26f)
            {
                collectCowsText.SetActive(false);
                cowDroughtText.SetActive(true);
                activeText = cowDroughtText;
            }

            if (textTimer > 33f)
            {
                cowDroughtText.SetActive(false);
                relieveDroughtText.SetActive(true);
                activeText = relieveDroughtText;
            }

            if (blocksSpawned == 5) // relieve cow drought
            {
                currentBlock = tutorialList[1];
            }

            // next fbi
            if (blocksSpawned == 6) // empty field, buffer for fbi
            {
                currentBlock = tutorialList[0];
            }

            if (blocksSpawned > 6 && blocksSpawned <= 7)
            {
                currentBlock = tutorialList[3];
            }

            if (textTimer > 45f)
            {
                relieveDroughtText.SetActive(false);
                FBI_text.SetActive(true);
                activeText = FBI_text;
            }

            // next dodge obstacles
            if (blocksSpawned == 8) // empty field, buffer for obstacles
            {
                currentBlock = tutorialList[0];
            }

            if (blocksSpawned > 8 && blocksSpawned <= 9)
            {
                currentBlock = tutorialList[4];
            }

            if (textTimer > 58f)
            {
                FBI_text.SetActive(false);
                obstacle_text.SetActive(true);
                activeText = obstacle_text;
            }

            // empty before ready to play
            if (blocksSpawned >= 11) // empty field, buffer for obstacles
            {
                currentBlock = tutorialList[0];
            }

            if (textTimer > 58f)
            {
                obstacle_text.SetActive(false);
            }

                // next empty field, ask to repeat tutorial or play game
                if (blocksSpawned > 12)
            {
                obstacle_text.SetActive(false);
                toSkipText.SetActive(false);
                
                StartCoroutine(DelayShowReady());
            }
        }
    }

    IEnumerator DelayShowReady()
    {
        yield return new WaitForSeconds(1f);
        readyToPlayPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
