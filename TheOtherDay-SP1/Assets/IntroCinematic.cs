using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCinematic : MonoBehaviour
{
    public Sprite[] sprite;
    public float[] duration;
    private Image img;

    private void Start()
    {
        img = gameObject.GetComponent<Image>();
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        for (int i = 0; i < sprite.Length; i++)
        {
            yield return new WaitForSeconds(duration[i]);
            if(i < sprite.Length - 1)
            {
                img.sprite = sprite[i + 1];
            }
        }
    }
}
