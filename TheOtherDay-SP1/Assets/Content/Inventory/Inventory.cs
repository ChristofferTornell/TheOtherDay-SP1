using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject itemBar;
    public GameObject itemSlotObj;
    public int itemSlotAmount;
    public InventoryManager inventoryManager;

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
        inventoryManager.itemSlots = new ItemSlot[itemSlotAmount];

        for (int i = 0; i < itemSlotAmount; i++)
        {
            GameObject iSlotObj = Instantiate(itemSlotObj);
            iSlotObj.transform.SetParent(itemBar.transform);
            ItemSlot iSlot = iSlotObj.GetComponent<ItemSlot>();
            iSlot.slotIndex = i;
            inventoryManager.itemSlots[i] = iSlot;
            iSlot.inventory = this;
        }
    }

    public void INV_AddItem(Items item)
    {
        if (GlobalData.instance.flashBack)
        {
            Debug.Log("cant add item outside of flashback");
            return;
        }
        foreach (ItemSlot iSlot in inventoryManager.itemSlots)
        {
            Debug.Log("checking each slot");
            if (iSlot.myItem == null)
            {
                Debug.Log("Adding item " + item.myName);
                iSlot.myItem = item;
                iSlot.myItemIcon.UpdateSprite(item.sprite);
                iSlot.myItem.myItemSlot = iSlot;
                return;
            }
        }
    }

    public bool INV_FindItem(Items item)
    {
        foreach (ItemSlot iSlot in inventoryManager.itemSlots)
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
        Debug.Log("Adding item " + _itemSlot);

        _itemSlot.myItem = null;
        _itemSlot.myItemIcon.UpdateSprite(nullSprite);
    }

    public void UpdateState()
    {
        if (GlobalData.instance.flashBack)
        {
            itemBar.gameObject.SetActive(true);
        }
        else
        {
            itemBar.gameObject.SetActive(false);
        }
    }
}
