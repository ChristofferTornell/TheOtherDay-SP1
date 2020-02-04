using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogueButton : MonoBehaviour
{
    public DialogueManager currentDialogueInstance;
    //public DialogueBox dialogueBoxUI;
    public Dialogue currentDialogue;

    public void GoToNextDialogue()
    {
        Debug.Log("Pressed button");
        currentDialogueInstance.currentDialogue = currentDialogue.nextDialogue;
    }
}
