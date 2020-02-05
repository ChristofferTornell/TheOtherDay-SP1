using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Items[] items;
    public Image[] image;

    private void Start()
    {
        image[0].sprite = items[1].sprite;
    }
}
