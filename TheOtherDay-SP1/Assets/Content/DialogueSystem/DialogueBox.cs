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
    public TextMeshProUGUI speakerNameObject = null;
    public Button nextButtonObject = null;
    public GameObject choiceButtonLayout = null;

    public DialogueProfile leftProfile = null;
    public DialogueProfile rightProfile = null;
    private bool rileySpeaking = true;

    public GameObject choiceButton;

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
            if (currentDialogue.choiceButtons.Length == 0)
            {
                DialogueManager.instance.ExitDialogue();
                ResetDialogueUI();
                return;
            }
            else
            {
                nextButtonObject.gameObject.SetActive(false);

                for (int i = 0; i < currentDialogue.choiceButtons.Length; i++)
                {
                    GameObject _choiceButton = Instantiate(choiceButton);
                    _choiceButton.transform.SetParent(choiceButtonLayout.transform);
                    _choiceButton.GetComponent<ChoiceButton>().textObject.text = currentDialogue.choiceButtons[i].buttonText;
                }
                return;
            }
        }
        nextButtonObject.gameObject.SetActive(true);
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

            rightProfile.profileImage.sprite = currentDialogue.listener.dialogImage;
            rightProfile.FadeOutColor();

        }
        else
        {
            textObject.alignment = TextAlignmentOptions.TopLeft;
            leftProfile.profileImage.sprite = currentDialogue.listener.dialogImage;
            leftProfile.FadeOutColor();

            rightProfile.profileImage.sprite = currentDialogue.speaker.dialogImage;
            rightProfile.FadeInColor();
        }

        speakerNameObject.text = currentDialogue.speaker.name;

    }

    public void ResetDialogueUI()
    {
        //currentDialogue = null;
        //textObject.text = "";
        //nextButtonObject = null;
        //leftProfile = null;
       // rightProfile = null;
    }

}
