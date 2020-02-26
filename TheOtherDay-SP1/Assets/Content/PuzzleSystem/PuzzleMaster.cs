using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaster : MonoBehaviour
{
    public RequiredItem[] requiredItems;
    public string goToSceneOnClear;
    
    public void RecieveItem()
    {
        //DeselectItem
        for (int i = 0; i < requiredItems.Length; i++)
        {
            if (PuzzleMouse.itemOnMouse == requiredItems[i].item && !requiredItems[i].isGiven)
            {
                Debug.Log("Correct item for puzzle");
                requiredItems[i].isGiven = true;
                PuzzleMouse.RemoveItem();
                if (PuzzleClear())
                {
                    Debug.Log("Exit flashback");
                    GetComponent<Interactable>().IE_ExitFlashback(goToSceneOnClear);
                }
                return;
            }
        }
    }
    public bool PuzzleClear()
    {
        foreach (RequiredItem _requiredItem in requiredItems)
        {
            if (!_requiredItem.isGiven)
            {
                Debug.Log("You still have item(s) to give to this PuzzleMaster");
                return false;
            }
        }
        return true;
    }
}
