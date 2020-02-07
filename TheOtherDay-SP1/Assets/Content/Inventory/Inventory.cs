using System.Collections;
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
        setItems();
    }

    public void addItem(Items item)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            int ID = itemSlots[i].GetComponent<ItemMenu>().ID;
            if(ID == 0)
            {
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

    private void setItems()
    {
        for (int i = 0; i < image.Length; i++)
        {
            image[i].sprite = items[type[i]].sprite;
        }
    }
}
