using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCow : MonoBehaviour
{
    public GameObject[] cowOptions;

    // Start is called before the first frame update
    void Start()
    {
        int prefabIndex = UnityEngine.Random.Range(0, 2);
        Instantiate(cowOptions[prefabIndex]);
    }
}
