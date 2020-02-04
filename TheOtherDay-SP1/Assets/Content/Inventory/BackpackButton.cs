using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackButton : MonoBehaviour
{
    public Button button;
    private bool inventory = false;
    public GameObject hotbar;

    private void Start()
    {
        button.onClick.AddListener(OnOff);
    }

    void OnOff()
    {
        if(inventory == false)
        {
            hotbar.SetActive(true);
            inventory = true;
        }
        else
        {
            hotbar.SetActive(false);
            inventory = false;
        }
    }
}
