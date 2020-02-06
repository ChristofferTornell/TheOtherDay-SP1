﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogueButton : MonoBehaviour
{
    //public DialogueBox dialogueBoxUI;
    public Dialogue currentDialogue;

    public void UpdateDialogue()
    {
        currentDialogue = DialogueManager.instance.currentDialogue;
    }

    public void GoToNextDialogue()
    {
        DialogueManager.instance.currentDialogue = currentDialogue.nextDialogue;
        DialogueManager.instance.dialogueBoxUI.TakeNewDialogue();
    }
}