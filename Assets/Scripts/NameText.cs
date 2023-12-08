using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameText : MonoBehaviour
{
    public TextMeshProUGUI nameUI;
    void Update()
    {

        //nameUI.text = string.Format(SceneManagement.sceneManager.names[AlienNames.alienNames.alienNameIndex - 1]);
        nameUI.text = SceneManagement.sceneManager.entryName;
    }
}
