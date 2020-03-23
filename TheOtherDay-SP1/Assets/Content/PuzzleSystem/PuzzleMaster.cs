using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaster : MonoBehaviour
{
    public RequiredItem[] requiredItems;
    public OptionalItem[] optionalItems;
    public string goToSceneOnClear;
    public bool exitFlashbackOnClear = false;
    public Dialogue clearDialogue;
    public Dialogue wrongItemDialogue;

    public void RecieveItem()
    {
        bool correctItem = false;
        //DeselectItem
        if (PuzzleMouse.itemOnMouse == null)
        {
            return;
        }
        if (optionalItems != null)
        {
            for (int i = 0; i < optionalItems.Length; i++)
            {
                if (PuzzleMouse.itemOnMouse == optionalItems[i].item)
                {
                    PuzzleMouse.RemoveItem();
                    DialogueManager.instance.EnterDialogue(optionalItems[i].recievedDialogue);
                    return;
                }
            }
        }
        for (int i = 0; i < requiredItems.Length; i++)
        {
            if (PuzzleMouse.itemOnMouse == requiredItems[i].item && !requiredItems[i].isGiven)
            {

                requiredItems[i].isGiven = true;
                Inventory.instance.INV_ClearItemSlot(PuzzleMouse.itemOnMouse.myItemSlot);
                PuzzleMouse.RemoveItem();
                if (requiredItems[i].recievedDialogue != null)
                {
                    DialogueManager.instance.EnterDialogue(requiredItems[i].recievedDialogue);
                }
                if (PuzzleClear() && exitFlashbackOnClear)
                {
                    Debug.Log("Exit flashback");
                    SceneChanger.instance.ExitFlashback(goToSceneOnClear);
                }
                correctItem = true;
                return;

            }
        }
        if (correctItem == false)
        {
            PuzzleMouse.RemoveItem();
            if (wrongItemDialogue != null)
            {
                DialogueManager.instance.EnterDialogue(wrongItemDialogue);
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
