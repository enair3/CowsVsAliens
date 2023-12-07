using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienNames : MonoBehaviour
{
    public static AlienNames alienNames;

    public List<string> names;
    public int alienNameIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        alienNames = this;

        names = new List<string>() { "myumyu", "raak" };/*, "sanzh", "kulipi",
                                    "aran", "ciqt", "veram", "teep", 
                                    "bbrhh", "wedxe"};*/
    }

    private void Update()
    {
        if (alienNameIndex == (names.Count - 1))
        {
            names.Add("team " + alienNameIndex.ToString());
        }
    }

}
