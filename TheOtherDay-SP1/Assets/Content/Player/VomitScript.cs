using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer = null;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;
    }
}