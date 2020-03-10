using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaterBottle", menuName = "ScriptableObjects/Items/WaterBottle", order = 1)]

public class ItemWaterBottle : Items
{
    public override void OnUse()
    {
        Debug.Log("i just drank water and decreased my hangover level");
        Inventory.instance.INV_ClearItemSlot(myItemSlot);
    }
}
