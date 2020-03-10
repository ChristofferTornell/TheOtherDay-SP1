using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryManager", menuName = "ScriptableObjects/InventoryManager", order = 5)]

public class InventoryManager : ScriptableObject
{
    public ItemSlot[] itemSlots;
}
