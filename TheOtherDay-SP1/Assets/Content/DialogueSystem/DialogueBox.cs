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
            textObject.alignment = TextAlignmentOptions.TopLeft;
            leftProfile.profileImage.sprite = currentDialogue.speaker.dialogImage;
            leftProfile.FadeInColor();
            leftProfile.profileName.text = currentDialogue.speaker.name;

            rightProfile.profileImage.sprite = currentDialogue.listener.dialogImage;
            rightProfile.FadeOutColor();
            rightProfile.profileName.text = currentDialogue.listener.name;

        }
        else
        {
            textObject.alignment = TextAlignmentOptions.TopRight;
            leftProfile.profileImage.sprite = currentDialogue.listener.dialogImage;
            leftProfile.FadeOutColor();
            leftProfile.profileName.text = currentDialogue.listener.name;

            rightProfile.profileImage.sprite = currentDialogue.speaker.dialogImage;
            rightProfile.FadeInColor();
            rightProfile.profileName.text = currentDialogue.speaker.name;
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
