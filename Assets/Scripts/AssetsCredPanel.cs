using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsCredPanel : MonoBehaviour
{
    public GameObject creds;
    
    // Start is called before the first frame update
    void Start()
    {
        creds.SetActive(false);
    }

    public void AssetCredits()
    {
        creds.SetActive(true);
    }
}
