using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Items[] items;
    public Image[] images;
    [Range(0, 2)]
    public Items[] itemsInInventory;

    private void Start()
    {
        //SetItems();
    }

    public ItemMenu[] itemMenuList;
    /*
    public bool CheckForItem(Items questItem)
    {
        for (int i = 0; i < itemMenuList.Length; i++)
        {
            if (itemMenuList[i] == questItem)
            {
                return
            }
        }
        //
        foreach (Items item in items)
        {
            if(item == questItem)
            {
                return true;
            }
        }
        return false;
        
    }*/


    public void INV_AddItem(Items item)
    {
        for(int i = 0; i < itemMenuList.Length; i++)
        {
            if(itemMenuList[i].isOccupied == false)
            {
                Debug.Log("Adding item " + item.myName);
                itemMenuList[i].isOccupied = true;
                itemMenuList[i].myItem = item;
                images[i].sprite = item.sprite;
                return;
            }
        }
    }
    /*
    public void INV_RemoveItem(int slot)
    {
        type[slot] = 0;
        images[slot].sprite = items[0].sprite;
    }

    public void INV_UseItem(int type)
    {

    }

    private void SetItems()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = items[type[i]].sprite;
        }
    }
    */
}
