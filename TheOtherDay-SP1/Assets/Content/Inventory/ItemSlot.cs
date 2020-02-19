using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Button btn;
    //public GameObject hideMenuButton;
    //public GameObject menu;
    public Inventory inventory;

    public Items myItem = null;
    public ItemIcon myItemIcon = null;

    
    void Start()
    {
        btn.onClick.AddListener(Click);
    }

    void Click()
    {
        //menu.SetActive(true);
        //hideMenuButton.SetActive(true);
        Debug.Log("You clicked me");
    }

    public void UseItem(Items item)
    {
        if(item.useable)
        {
            item.OnUse();
        }
        else
        {
            Debug.Log("You can not use this item");
        }
    }

    public void ExamineItem(Items item)
    {
        inventory.descriptionBoxNameTextObj.text = item.myName;
        inventory.descriptionBoxDescriptionTextObj.text = item.description;
        inventory.descriptionBoxImageObj.sprite = item.sprite;

        inventory.descriptionBoxObj.SetActive(true);
    }

    public void ExitExamineMenu()
    {
        inventory.descriptionBoxObj.SetActive(false);
    }
}
