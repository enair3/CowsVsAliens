using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    [SerializeField] Renderer backgroundRenderer;

    // Update is called once per frame
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0f, scrollSpeed * Time.deltaTime);
    }

}
