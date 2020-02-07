﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Items[] items;
    public Image[] image;
    public GameObject[] itemSlots;
    [Range(0, 2)]
    public int[] type;

    private void Start()
    {
        SetItems();
    }

    public void INV_AddItem(Items item)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            int ID = itemSlots[i].GetComponent<ItemMenu>().ID;
            if(ID == 0)
            {
                Debug.Log("Adding item " + item.name);

                image[i].sprite = item.sprite;
                switch (item.name)
                {
            
                    case "Water Bottle":
                        itemSlots[i].GetComponent<ItemMenu>().ID = 1;
                    break;

                    case "Backpack":
                        itemSlots[i].GetComponent<ItemMenu>().ID = 1;
                    break;
                }
                return;
            }
        }
    }

    private void SetItems()
    {
        for (int i = 0; i < image.Length; i++)
        {
            image[i].sprite = items[type[i]].sprite;
        }
    }
}
