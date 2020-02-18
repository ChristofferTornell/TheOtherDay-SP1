using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Button btn;
    public GameObject hideMenuButton;
    public GameObject menu;

    public Items myItem = null;
    [HideInInspector]public bool isOccupied = false;
    public ItemIcon myItemIcon = null;

    /*
    void Start()
    {
        if(myItem == null)
        {
            isOccupied = false;
        }
        GameObject parent = transform.parent.parent.gameObject;
        type = parent.GetComponent<Inventory>().type;
        btn.onClick.AddListener(Click);
    }

    void Click()
    {
        if(type[ID] != 0 && type[ID] != 1)
        {
            menu.SetActive(true);
            rest.SetActive(true);
        }
        else if(type[ID] == 1)
        {
            UseItem(1);
        }
    }

    public void UseItem(int type)
    {
        if(type == 1)
        {
            bp.INV_RemoveItem(ID);
            Debug.Log("You drank water, hungover level decreased");
        }
        else if(type == 2)
        {
            Debug.Log("You opened a backpack in a packpack");
        }
    }*/
}
