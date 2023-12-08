using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameText : MonoBehaviour
{
    public TextMeshProUGUI nameUI;
    public static NameText nameText;
    public static NameText Instance;

    private void Start()
    {
        nameText = this;
        DontDestroyOnLoad(nameText);

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

        //nameUI.text = string.Format(SceneManagement.sceneManager.names[AlienNames.alienNames.alienNameIndex - 1]);
        nameUI.text = SceneManagement.Instance.entryName;
    }
}
