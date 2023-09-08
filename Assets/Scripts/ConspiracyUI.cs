using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConspiracyUI : MonoBehaviour
{
    public TextMeshProUGUI conspiracyText;
    public PlayerControllerDEMO playerBehavior;

    // Update is called once per frame
    void Update()
    {
        conspiracyText.text = string.Format("Conspiracy: {0}", playerBehavior.conspiracy);
    }
}
