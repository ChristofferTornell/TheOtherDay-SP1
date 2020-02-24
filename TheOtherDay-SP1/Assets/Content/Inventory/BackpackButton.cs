using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackButton : MonoBehaviour
{
    public Button button;
    private bool inventoryOpen = false;
    public InventoryManager inventoryManager;
    public GameObject hotbar;

    private void Start()
    {
        button.onClick.AddListener(OnOff);
    }

    void OnOff()
    {
        foreach (ItemSlot iSlot in inventoryManager.itemSlots)
        {
            iSlot.menu.SetActive(false);
        }

        if (inventoryOpen == false)
        {
            hotbar.SetActive(true);
            inventoryOpen = true;
        }
        else
        {
            hotbar.SetActive(false);
            inventoryOpen = false;
        }
    }
}
