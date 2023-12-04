using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsCredPanel : MonoBehaviour
{
    public GameObject creds;
    public GameObject roles;
    public GameObject thisButton;
    
    // Start is called before the first frame update
    void Start()
    {
        creds.SetActive(false);
        roles.SetActive(true);
        thisButton.SetActive(false);
    }

    public void AssetCredits()
    {
        StartCoroutine(DelayShow());
        
        //thisButton.enabled = true;
    }

    IEnumerator DelayShow()
    {
        yield return new WaitForSeconds(0.8f);
        creds.SetActive(true);
        roles.SetActive(false);
        thisButton.SetActive(true);
    }
}
