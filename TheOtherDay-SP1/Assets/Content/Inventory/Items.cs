using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemTemplate", menuName = "ScriptableObjects/Items/ItemTemplate", order = 0)]

public class Items : ScriptableObject
{
    public Sprite icon;
    public string myName;
    public bool useable = false;
    public ItemSlot myItemSlot;

    [TextArea(3, 7)]
    public string description;

    public virtual void OnUse()
    {
       
    }
}
