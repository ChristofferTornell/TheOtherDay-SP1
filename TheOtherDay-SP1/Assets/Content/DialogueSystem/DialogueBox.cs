using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    //[HideInInspector]
    public Dialogue currentDialogue = null;
    public TextMeshProUGUI textObject = null;
    public Button nextButtonObject = null;
    public DialogueProfile leftProfile = null;
    public DialogueProfile rightProfile = null;
    private bool rileySpeaking = true;

    public void InitializeDialogueUI()
    {
        currentDialogue = DialogueManager.instance.currentDialogue;
        UpdateDialogueUI();
    }

    public void TakeNewDialogue()
    {
        ResetDialogueUI();
        UpdateDialogueUI();
    }

    public void UpdateDialogueUI()
    {
        if (DialogueManager.instance.currentDialogue == null)
        {
            DialogueManager.instance.ExitDialogue();
            ResetDialogueUI();
            return;
        }
        currentDialogue = DialogueManager.instance.currentDialogue;
        Debug.Log(currentDialogue);
        nextButtonObject.GetComponent<NextDialogueButton>().UpdateDialogue();
        textObject.text = currentDialogue.message;
        if (currentDialogue.speaker.name == "Riley")
        {
            rileySpeaking = true;
        }
        else
        {
            rileySpeaking = false;
        }

        if (rileySpeaking)
        {
            //Left alignment
            leftProfile.profileImage.sprite = currentDialogue.speaker.dialogImage;
            leftProfile.profileImage.name = currentDialogue.speaker.name;

            rightProfile.profileImage.sprite = currentDialogue.listener.dialogImage;
            rightProfile.profileImage.name = currentDialogue.listener.name;
        }
        else
        {
            //Right alignment
            leftProfile.profileImage.sprite = currentDialogue.listener.dialogImage;
            leftProfile.profileImage.name = currentDialogue.listener.name;

            rightProfile.profileImage.sprite = currentDialogue.speaker.dialogImage;
            rightProfile.profileImage.name = currentDialogue.speaker.name;
        }

    }

    public void ResetDialogueUI()
    {
        currentDialogue = null;
        //textObject.text = "";
        //nextButtonObject = null;
        //leftProfile = null;
       // rightProfile = null;
    }

}
