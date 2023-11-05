using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConspiracyUI : MonoBehaviour
{
    public TextMeshProUGUI conspiracyText;
    public Slider conspiracyMeter;

    public Gradient conspiracyGradient; // edit when colors decided for increments
    
    
    // Update is called once per frame
    void Update()
    {
        conspiracyText.text = string.Format("Conspiracy: {0}", PlayerController.playerInfo.conspiracy);
        conspiracyMeter.value = PlayerController.playerInfo.conspiracy;

        //gradient.Evaluate(1f);
    }
}
