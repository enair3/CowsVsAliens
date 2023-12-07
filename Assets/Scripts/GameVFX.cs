using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVFX : MonoBehaviour
{
    //public static GameVFX gameVFX;
    private Vector3 cowScale;

    // env, ui
    public ParticleSystem[] playerParticles;
    public GameObject redBorder;
    public GameObject alertSFX;
    public GameObject cowFall;

    public GameObject happyUp;
    public GameObject conspiracyUp;

    public GameObject obsExplosion_anim;

    // cow
    public bool gotCow;
    public float cowVFX_timer;

    // fbi
    public bool gotFBI;
    public float fbiVFX_timer;

    // obs
    public bool gotHit;
    public float obsVFX_timer;

    // Start is called before the first frame update
    void Start()
    {
        redBorder.SetActive(false);
        alertSFX.GetComponent<AudioSource>().Stop();

        cowFall.SetActive(false);

        gotCow = false;
        cowVFX_timer = 1f;
        happyUp.SetActive(false);

        gotFBI = false;
        fbiVFX_timer = 1f;
        conspiracyUp.SetActive(false);

        gotHit = false;
        obsVFX_timer = 0.5f;
        obsExplosion_anim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // red border alert
        if (PlayerController.playerInfo.conspiracy >= (PlayerController.playerInfo.maxConspiracy * 0.6) 
            || PlayerController.playerInfo.happiness <= (PlayerController.playerInfo.maxHappiness * 0.4))
        {
            redBorder.SetActive(true);
            alertSFX.GetComponent<AudioSource>().Play();
        }
        else
        {
            redBorder.SetActive(false);
            alertSFX.GetComponent<AudioSource>().Stop();
        }

        // got cow
        if (gotCow == true)
        {
            CowVFX();
        }

        //Debug.Log(cowVFX_timer);
        // got fbi
        if (gotFBI == true)
        {
            FBIVFX();
        }

        // got hit
        if (gotHit == true)
        {
            ObsVFX();
        }
    }

    private void CowVFX()
    {
        cowVFX_timer -= Time.deltaTime;

        // start vfx
        playerParticles[0].Play();
        happyUp.SetActive(true);

        if (cowVFX_timer <= 0)
        {
            Debug.Log("timer start");
            cowVFX_timer = 1f;
            gotCow = false;
            playerParticles[0].Stop();
            happyUp.SetActive(false);
        }
    }

    private void FBIVFX()
    {
        fbiVFX_timer -= Time.deltaTime;

        // start vfx
        playerParticles[1].Play();
        
        if (PlayerController.playerInfo.cowCount != 0)
        {
            Vector3 cowScale = cowFall.GetComponent<RectTransform>().localScale;
            cowScale.x *= -1;
            cowFall.GetComponent<RectTransform>().localScale = cowScale;

            cowFall.SetActive(true);
        }

        if (fbiVFX_timer <= 0)
        {
            Debug.Log("timer start");
            fbiVFX_timer = 1f;
            gotFBI = false;
            playerParticles[1].Stop();
            cowFall.SetActive(false);
            // conspiracyUP activated in FBIBehavior script
        }
    }

    private void ObsVFX()
    {
        obsVFX_timer -= Time.deltaTime;

        // start vfx, DD NO FALL COW WHEN COUNT = 0
        playerParticles[2].Play();
        obsExplosion_anim.SetActive(true);

        if (PlayerController.playerInfo.cowCount != 0)
        {
            //rand = Random.Range(0, 2);

            cowFall.SetActive(true);
        }

        if (obsVFX_timer <= 0)
        {
            Debug.Log("timer start");
            obsVFX_timer = 1f;
            gotHit = false;
            playerParticles[2].Stop();
            obsExplosion_anim.SetActive(false);
            cowFall.SetActive(false);
        }
    }
}
