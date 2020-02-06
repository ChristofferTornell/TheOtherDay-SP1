using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceButton : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    public int myId;
    public Dialogue currentDialogue;

    public void Start()
    {
        currentDialogue = DialogueManager.instance.currentDialogue;
    }

    public void GoToNextDialogue()
    {
        DialogueManager.instance.currentDialogue = currentDialogue.choiceButtons[myId].nextDialogue;
        DialogueManager.instance.dialogueBoxUI.TakeNewDialogue();
    }
}
