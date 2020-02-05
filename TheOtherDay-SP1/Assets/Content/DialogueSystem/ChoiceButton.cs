using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceButton : MonoBehaviour
{
    public TextMeshProUGUI textObject;

    public Dialogue currentDialogue;

    public void UpdateDialogue()
    {
        currentDialogue = DialogueManager.instance.currentDialogue;
    }

    public void GoToNextDialogue()
    {
        Debug.Log("pressed next button");
        DialogueManager.instance.currentDialogue = currentDialogue.nextDialogue;
        DialogueManager.instance.dialogueBoxUI.TakeNewDialogue();
    }
}
