using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public ScrollingBackgroundData data;
    public Renderer myRenderer;

    private void Update()
    {
        myRenderer.material.mainTextureOffset += new Vector2(data.scrollingSpeed * Time.deltaTime, 0f);
    }
}
