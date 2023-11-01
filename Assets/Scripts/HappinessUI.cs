using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HappinessUI : MonoBehaviour
{
    public TextMeshProUGUI happinessText;
    public Slider happinessMeter;

    public Gradient conspiracyGradient; // edit when colors decided for increments

    // Update is called once per frame
    void Update()
    {
        happinessText.text = string.Format("Happiness: {0}", BCollect_PlayerController.playerInfo.happiness);
        happinessMeter.value = BCollect_PlayerController.playerInfo.happiness;

        //gradient.Evaluate(1f);
    }
}
