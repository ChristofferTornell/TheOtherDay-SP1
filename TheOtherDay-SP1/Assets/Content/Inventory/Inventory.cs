using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Items[] item;
    public Image image;
    [Range(0, 2)]
    public int ID = 0;

    private void Start()
    {
        image.sprite = item[ID].sprite;
    }
}
