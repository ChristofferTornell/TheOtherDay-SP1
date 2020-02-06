using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Items[] items;
    public Image[] image;
    [Range(0, 2)]
    public int[] type;

    private void Start()
    {
        for(int i = 0; i < image.Length; i++)
        {
            image[i].sprite = items[type[i]].sprite;
        }
    }
}
