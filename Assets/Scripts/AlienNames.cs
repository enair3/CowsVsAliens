using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienNames : MonoBehaviour
{
    public static AlienNames alienNames;

    public List<string> names = new List<string>();
    public int alienNameIndex = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        alienNames = this;

        names = new List<string>() {"myumy", "raak" , "sanzh", "kulip",
                                    "aran", "ciqt", "veram", "teep", 
                                    "bbrhh", "wedxe"};
    }

    private void Update()
    {
        if (alienNameIndex == (names.Count - 1))
        {
            names.Add("te " + alienNameIndex.ToString());
        }
    }

}
