using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CowCountUI : MonoBehaviour
{
    public TextMeshProUGUI cowCountText;

    // Update is called once per frame
    void Update()
    {
        cowCountText.text = string.Format("Cows Collected: {0}", BCollect_PlayerController.playerInfo.cowCount);
    }
}
