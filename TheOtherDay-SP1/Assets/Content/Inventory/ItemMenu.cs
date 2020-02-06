using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    public Button btn;
    public GameObject menu;
    public int ID;
    private int[] type;

    void Start()
    {
        GameObject parent = transform.parent.parent.gameObject;
        type = parent.GetComponent<Inventory>().type;
        btn.onClick.AddListener(click);
    }

    void click()
    {
        if(type[ID] != 0)
        {
            Debug.Log(type[ID]);
            menu.SetActive(true);
        }
    }
}
