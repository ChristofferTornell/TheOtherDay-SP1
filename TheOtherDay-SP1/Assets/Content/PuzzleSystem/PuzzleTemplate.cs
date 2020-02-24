using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTemplate : ScriptableObject
{
    public bool isCleared = false;
    public Items[] itemList;

    public void CheckItems()
    {
        foreach (Items puzzleItem in itemList)
        {
            if (Inventory.instance.INV_FindItem(puzzleItem))
            {
                isCleared = true;
                Debug.Log("You had the items you needed! Puzzle complete.");
            }
            else
            {
                Debug.Log("You do not have the items you need to complete this puzzle.");
            }
        }
    }

}
