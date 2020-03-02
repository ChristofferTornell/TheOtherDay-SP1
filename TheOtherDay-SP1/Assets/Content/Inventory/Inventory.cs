using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject itemBar;
    public ItemSlot[] itemSlots;

    [HideInInspector] public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    private void Start()
    {
        //inventoryManager = InventoryData.instance.manager;
        //inventoryManager.itemSlots = new ItemSlot[itemSlotAmount];
        /*
        for (int i = 0; i < itemSlotAmount; i++)
        {
            GameObject iSlotObj = Instantiate(itemSlotObj);
            iSlotObj.transform.SetParent(itemBar.transform);
            ItemSlot iSlot = iSlotObj.GetComponent<ItemSlot>();
            iSlot.slotIndex = i;
            inventoryManager.itemSlots[i] = iSlot;
            iSlot.inventory = this;
        }
        */
    }

    public void INV_AddItem(Items item)
    {
        if (!GlobalData.instance.flashBack)
        {
            Debug.Log("cant add item outside of flashback");
            return;
        }
        foreach (ItemSlot iSlot in itemSlots)
        {
            if (iSlot.myItem == null)
            {
                Debug.Log("Adding item " + item.myName);
                iSlot.UpdateSlot(item);
                return;
            }
        }
    }

    public bool INV_FindItem(Items item)
    {
        foreach (ItemSlot iSlot in itemSlots)
        {
            if (iSlot.myItem == item)
            {
                Debug.Log("Found item " + item.myName);
                return true;
            }
        }
        return false;
    }

    public Sprite nullSprite;

    public void INV_ClearItemSlot(ItemSlot _itemSlot)
    {
        Debug.Log("Clearing slot" + _itemSlot);

        _itemSlot.myItem = null;
        _itemSlot.myItemIcon.UpdateSprite(nullSprite);
    }
}
