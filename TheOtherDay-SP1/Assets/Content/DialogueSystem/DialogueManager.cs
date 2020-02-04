using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Dialogue currentDialogue = null;
    public DialogueBox dialogueBoxUI = null;
    private bool dialogueActive = false;

    public static DialogueManager instance;

    void Awake()
    {
        instance = this;
    }
    void EnterDialogue()
    {
        dialogueBoxUI.enabled = true;
    }

    void ExitDialogue()
    {
        dialogueBoxUI.enabled = false;
    }

}
