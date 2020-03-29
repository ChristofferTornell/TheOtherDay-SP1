using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [HideInInspector] public Dialogue currentDialogue = null;
    public DialogueBox dialogueBoxUI = null;
    public static bool dialogueActive = false;
    public GameObject phone;


    public static DialogueManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        dialogueBoxUI.gameObject.SetActive(false);
    }

    public void EnterDialogue(Dialogue initialDialogue)
    {
        if (GlobalData.instance.flashBack)
        {
            Inventory.instance.INV_Hide();
        }
        currentDialogue = initialDialogue;
        dialogueBoxUI.gameObject.SetActive(true);
        dialogueBoxUI.InitializeDialogueUI();
        PlayerMovement.playerMovementLocked = true;
        DescriptionUI.instance.descriptionBoxObj.SetActive(false);
        PuzzleMouse.RemoveItem();
        if (Phone.Pulled && !currentDialogue.ignorePhone) { BackButton.instance.OutsideButton(); };
        //phone.SetActive(false);
        dialogueActive = true;
    }

    public void ExitDialogue()
    {
        dialogueBoxUI.DestroyChoiceButtons();
        dialogueBoxUI.EndDialogue();
        if (GlobalData.instance.flashBack)
        {
            Inventory.instance.INV_Appear();
        }
        dialogueBoxUI.gameObject.SetActive(false);
        //phone.SetActive(true);
        if (!Phone.Pulled)
        {
            PlayerMovement.playerMovementLocked = false;
        }

        if (PlayerMovement.playerInstance.GetComponent<PlayerInteractivity>().interactables.Count > 0)
        {
            PlayerMovement.playerInstance.GetComponent<PlayerInteractivity>().interactUI.SetActive(true);
        }
        if (PuzzleMouse.overInteractable)
        {
            if(PuzzleMouse.currentlyHovered != null)
            {
                PuzzleMouse.SetHoverText(PuzzleMouse.currentlyHovered.gameObject.name);
                GameController gameController = FindObjectOfType<GameController>();
                gameController.ChangeCursor(PuzzleMouse.currentlyHovered.hoverCursor);
            }
        }
        
        /*
        if (PlayerMovement.playerInstance.GetComponent<PlayerInteractivity>().interactableObject != null)
        {
            DescriptionUI.instance.gameObject.SetActive(true);
        }
        */
        dialogueActive = false;
    }

}
