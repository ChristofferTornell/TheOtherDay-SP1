using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Button btn;
    //public GameObject hideMenuButton;
    public GameObject menu;
    [HideInInspector] public Inventory inventory;

    public Items myItem = null;
    public ItemIcon myItemIcon = null;
    public int slotIndex;

    
    void Start()
    {
        btn.onClick.AddListener(Click);
        inventory = Inventory.instance;
        Debug.Log("Inventory instance: " + inventory.GetHashCode().ToString());
        foreach (ItemSlot _iSlot in inventory.inventoryManager.itemSlots)
        {
            if (_iSlot.myItem != null)
            {
                inventory.INV_AddItem(_iSlot.myItem);
            }
        }
    }

    void Click()
    {
        Debug.Log("clicked on itemslot");
        if (myItem == null)
        {
            Debug.Log("I dont have an item :(");
            return;
        }
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
        //hideMenuButton.SetActive(true);
    }

    public void UseItem()
    {
        if(myItem.useable)
        {
            PuzzleMouse.SetItemOnMouse(myItem);
            myItem.OnUse();
        }
        else
        {
            Debug.Log("You can not use this item: " + myItem);
        }
        menu.SetActive(false);
    }

    public void ExamineItem()
    {

        DescriptionUI.instance.ExamineItem(myItem);
        menu.SetActive(false);
    }

}
