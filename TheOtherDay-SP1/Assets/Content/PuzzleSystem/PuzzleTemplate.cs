using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTemplate : ScriptableObject
{
    public bool isCleared = false;
    public Items[] itemList;
    public CharacterData npc;

    public void CheckItems()
    {
        foreach  (Items item in itemList)
        {
            
        }
    }

}
