using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThisDouble : MonoBehaviour
{
    private List<GameObject> spawnedObjects = new List<GameObject>(); // keep track of what's spawned

    // spawning vars
    public int blocksSpawned;
    [SerializeField] private float timeBetweenSpawn_blocks;

    // music
    private GameObject musicMain;
    private GameObject musicHideout;

    public bool hideoutOn;
    public int hideoutProb;
    public GameObject hideoutAlert_text;

    // BLOCKS to spawn
    // intro progression
    public List<GameObject> activeList;
    public List<GameObject> easy;
    public List<GameObject> med;
    public List<GameObject> hard;

    // random and event
    public List<GameObject> regularBlocks;
    public List<GameObject> hideoutBlocks;

    //public static List<GameObject[]> allBlocks;

    // class for difficulty to randomize between 2 or more difficulties

    public void Start()
    {
        timeBetweenSpawn_blocks = 6.5f;
        blocksSpawned = 0;
        hideoutProb = 4;

        musicMain = GameObject.Find("AudioSource_music");
        musicMain.GetComponent<AudioSource>().Play();

        musicHideout = GameObject.Find("AudioSource_hideout");
        hideoutOn = false;
        hideoutAlert_text.SetActive(false);

        // load first
        foreach (var e in easy)
        {
            regularBlocks.Add(e);
        }
        foreach (var m in med)
        {
            regularBlocks.Add(m);
        }
        foreach (var h in hard)
        {
            regularBlocks.Add(h);
        }

        activeList = easy;

        InvokeRepeating("SpawnBlocks", 0f, timeBetweenSpawn_blocks);
    }

    private void Update()
    { 
        BlockProgression();
    }

    // level design block spawning
    void SpawnBlocks()
    {
        WaitForSeconds resetTime = new WaitForSeconds(timeBetweenSpawn_blocks);
        GameObject prefab = activeList[Random.Range(0, activeList.Count)]; // will need to revise to include order
        GameObject clone = Instantiate(prefab, transform.position,
            transform.rotation);

        // add spawned to list
        spawnedObjects.Add(clone);

        blocksSpawned++;
    }

    void BlockProgression()
    {
        if (blocksSpawned > 2 && blocksSpawned <= 4)
        {
            activeList = med;
        }

        if (blocksSpawned > 4 && blocksSpawned <= 6)
        {
            activeList = hard;
        }

        if (blocksSpawned > 8) //15, incr by 5
        {
            activeList = regularBlocks;
        }

        // when hideout block spawns


        /*// random prob hideout special event
       if (blocksSpawned % 4 == 0)
       {
           hideoutOn = true;
           musicMain.GetComponent<AudioSource>().volume = 0.15f;
           musicHideout.GetComponent<AudioSource>().Play();

           hideoutAlert_text.SetActive(true);
           //hideoutAlert_text.GetComponent<UIVertex>().color.a += Time.deltaTime;
           activeList = hideoutBlocks;


           Debug.Log("hideout activated");
       }
       else
       {
           hideoutOn = false;
           musicMain.GetComponent<AudioSource>().volume = 0.5f;

           hideoutAlert_text.SetActive(false);
           activeList = regularBlocks;
       } */
    }

    // if hideout block spawns
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hideout")
        {
            hideoutOn = true;
            musicMain.GetComponent<AudioSource>().volume = 0.05f;
            musicHideout.GetComponent<AudioSource>().Play();

            hideoutAlert_text.SetActive(true);
            //hideoutAlert_text.GetComponent<UIVertex>().color.a += Time.deltaTime;
            activeList = hideoutBlocks;

            Debug.Log("hideout activated");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "hideout")
        {
            hideoutOn = false;
            musicMain.GetComponent<AudioSource>().volume = 0.5f;

            hideoutAlert_text.SetActive(false);
            activeList = regularBlocks;
        }
    }
}
