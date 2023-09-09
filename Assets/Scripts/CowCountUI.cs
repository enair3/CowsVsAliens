using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CowCountUI : MonoBehaviour
{
    public TextMeshProUGUI cowCountText;
    //public PlayerControllerDEMO playerBehavior;

    // Update is called once per frame
    void Update()
    {
        cowCountText.text = string.Format("Cows Collected: {0}", PlayerControllerDEMO.player.cowCount);
    }
}
