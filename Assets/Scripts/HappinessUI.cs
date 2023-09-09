using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HappinessUI : MonoBehaviour
{
    public TextMeshProUGUI happinessText;
    //public PlayerControllerDEMO playerBehavior;

    // Update is called once per frame
    void Update()
    {
        happinessText.text = string.Format("Happiness: {0}", PlayerControllerDEMO.player.happiness);
    }
}
