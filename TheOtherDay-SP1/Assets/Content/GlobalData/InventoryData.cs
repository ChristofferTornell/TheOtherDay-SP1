using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public static InventoryData instance;
    public InventoryManager manager;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
