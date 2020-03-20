using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [FMODUnity.EventRef] public string addItemSoundEvent;
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

    public void INV_Hide()
    {
        itemBar.SetActive(false);
        foreach(ItemSlot iSlot in itemSlots)
        {
            iSlot.menu.SetActive(false);
        }
    }

    public void INV_Appear()
    {
        itemBar.SetActive(true);
    }
    public void INV_AddItem(Items item)
    {
        PuzzleMouse.RemoveItem();
        if (!GlobalData.instance.flashBack)
        {
            Debug.Log("cant add item outside of flashback");
            return;
        }
        foreach (ItemSlot iSlot in itemSlots)
        {
            if (iSlot.myItem == null)
            {
                FMODUnity.RuntimeManager.PlayOneShot(addItemSoundEvent);
                //Debug.Log("Adding item " + item.myName);
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
                //Debug.Log("Found item " + item.myName);
                return true;
            }
        }
        return false;
    }

    public Sprite nullSprite;

    public void INV_ClearItemSlot(ItemSlot _itemSlot)
    {
        _itemSlot.myItem = null;
        _itemSlot.myItemIcon.UpdateSprite(nullSprite);
    }
}
