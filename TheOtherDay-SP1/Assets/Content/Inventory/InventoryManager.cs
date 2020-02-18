using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemBar;
    public GameObject itemSlotObj;
    public int itemSlotAmount;
    [HideInInspector] public ItemSlot[] itemSlots;

    private void Start()
    {
        itemSlots = new ItemSlot[itemSlotAmount];

        for (int i = 0; i < itemSlotAmount; i++)
        {
            GameObject iSlotObj = Instantiate(itemSlotObj);
            iSlotObj.transform.SetParent(itemBar.transform);
            ItemSlot iSlot = iSlotObj.GetComponent<ItemSlot>();
            itemSlots[i] = iSlot;
        }
    }

    public void INV_AddItem(Items item)
    {
        foreach (ItemSlot iSlot in itemSlots)
        {
            if (iSlot.isOccupied == false)
            {
                Debug.Log("Adding item " + item.myName);
                iSlot.isOccupied = true;
                iSlot.myItem = item;
                iSlot.myItemIcon.UpdateSprite(item.sprite);
                return;
            }
        }
    }

    public Sprite nullSprite;

    public void INV_ClearItemSlot(ItemSlot _itemSlot)
    {
        Debug.Log("Adding item " + _itemSlot);

        _itemSlot.myItem = null;
        _itemSlot.isOccupied = false;
        _itemSlot.myItemIcon.UpdateSprite(nullSprite);
    }
}
