using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaster : MonoBehaviour
{
    public RequiredItem[] requiredItems;
    public string goToSceneOnClear;
    public bool exitFlashbackOnClear = false;
    public Dialogue clearDialogue;
    
    public void RecieveItem()
    {
        //DeselectItem
        for (int i = 0; i < requiredItems.Length; i++)
        {
            if (PuzzleMouse.itemOnMouse == requiredItems[i].item && !requiredItems[i].isGiven)
            {
                if (requiredItems[i].recievedDialogue != null)
                {
                    DialogueManager.instance.EnterDialogue(requiredItems[i].recievedDialogue);
                }
                requiredItems[i].isGiven = true;
                Inventory.instance.INV_ClearItemSlot(PuzzleMouse.itemOnMouse.myItemSlot);
                PuzzleMouse.RemoveItem();
                if (PuzzleClear() && exitFlashbackOnClear)
                {
                    Debug.Log("Exit flashback");
                    SceneChanger.instance.ExitFlashback(goToSceneOnClear);
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
                return false;
            }
        }
        return true;
    }
}
