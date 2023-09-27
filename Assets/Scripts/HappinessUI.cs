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
        happinessText.text = string.Format("Happiness: {0}", PlayerControllerDEMO.playerInfo.happiness);
        happinessMeter.value = PlayerControllerDEMO.playerInfo.happiness;

        //gradient.Evaluate(1f);
    }
}
