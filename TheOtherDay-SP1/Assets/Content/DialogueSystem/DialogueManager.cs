using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [HideInInspector] public Dialogue currentDialogue = null;
    public DialogueBox dialogueBoxUI = null;
    public static bool dialogueActive = false;

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
        currentDialogue = initialDialogue;
        dialogueBoxUI.gameObject.SetActive(true);
        dialogueBoxUI.InitializeDialogueUI();
        PlayerMovement.playerMovementLocked = true;
        dialogueActive = true;
    }

    public void ExitDialogue()
    {
        dialogueBoxUI.gameObject.SetActive(false);
        PlayerMovement.playerMovementLocked = false;
        dialogueActive = false;
    }

}
