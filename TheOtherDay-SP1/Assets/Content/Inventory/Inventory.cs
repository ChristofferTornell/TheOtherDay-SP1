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

    public GameObject descriptionBoxObj;
    public TextMeshProUGUI descriptionBoxDescriptionTextObj;
    public TextMeshProUGUI descriptionBoxNameTextObj;
    public Image descriptionBoxImageObj;

    public Button backpackButton;



    [HideInInspector] public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    private void Start()
    {
        backpackButton = GetComponent<BackpackButton>().button;
        inventoryManager.itemSlots = new ItemSlot[itemSlotAmount];

        for (int i = 0; i < itemSlotAmount; i++)
        {
            GameObject iSlotObj = Instantiate(itemSlotObj);
            iSlotObj.transform.SetParent(itemBar.transform);
            ItemSlot iSlot = iSlotObj.GetComponent<ItemSlot>();
            inventoryManager.itemSlots[i] = iSlot;
            iSlot.inventory = this;
            iSlot.btn = backpackButton;
        }
    }

    public void INV_AddItem(Items item)
    {
        foreach (ItemSlot iSlot in inventoryManager.itemSlots)
        {
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

}
