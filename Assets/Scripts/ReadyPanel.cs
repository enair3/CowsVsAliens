using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPanel : MonoBehaviour
{

    public GameObject readyPanel;

    public void DeactivatePanel()
    {
        readyPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
