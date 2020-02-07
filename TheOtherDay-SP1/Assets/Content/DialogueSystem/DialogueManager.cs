using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [HideInInspector] public Dialogue currentDialogue = null;
    public DialogueBox dialogueBoxUI = null;
    private bool dialogueActive = false;

    public static DialogueManager instance;

    void Awake()
    {
        dialogueBoxUI.gameObject.SetActive(false);
        instance = this;
    }
    public void EnterDialogue(Dialogue initialDialogue)
    {
        currentDialogue = initialDialogue;
        dialogueBoxUI.gameObject.SetActive(true);
        dialogueBoxUI.InitializeDialogueUI();
    }

    public void ExitDialogue()
    {
        dialogueBoxUI.gameObject.SetActive(false);
    }

}
