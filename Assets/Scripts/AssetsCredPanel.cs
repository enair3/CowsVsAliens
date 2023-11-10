using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsCredPanel : MonoBehaviour
{
    public GameObject creds;
    public GameObject thisButton;
    
    // Start is called before the first frame update
    void Start()
    {
        creds.SetActive(false);
        thisButton.SetActive(false);
    }

    public void AssetCredits()
    {
        StartCoroutine(DelayShow());
        creds.SetActive(true);
        //thisButton.enabled = true;
    }

    IEnumerator DelayShow()
    {
        yield return new WaitForSeconds(1f);
        thisButton.SetActive(true);
    }
}
