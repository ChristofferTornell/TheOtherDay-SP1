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

    public DialogueProfile rileyProfile = null;
    public DialogueProfile NPCprofile = null;
    private bool rileySpeaking = true;

    public GameObject choiceButton;
    private bool choiceButtonsExist = false;

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

    IEnumerator AutotypeText(string inputMessage, float delay, string typingSound)
    {
        for (int i = 0; i < inputMessage.Length; i++)
        {
            textObject.text = inputMessage.Substring(0, i+1);
            //FMODUnity.RuntimeManager.PlayOneShot(typingSound); IMPLEMENT AUDIO
            yield return new WaitForSeconds(delay);
        }

    }

    public void UpdateDialogueUI()
    {
        StopAllCoroutines();
        if (choiceButtonsExist)
        {
            foreach (Transform child in choiceButtonLayout.transform)
            {
                Destroy(child.gameObject);
            }
        }
        if (currentDialogue.nextDialogue == null)
        {
            if (currentDialogue.choiceButtons.Length == 0)
            {
                DialogueManager.instance.ExitDialogue();
                ResetDialogueUI();
                return;
            }
            
        }
        nextButtonObject.gameObject.SetActive(true);
        currentDialogue = DialogueManager.instance.currentDialogue;
        nextButtonObject.GetComponent<NextDialogueButton>().UpdateDialogue();
        StartCoroutine(AutotypeText(currentDialogue.message, currentDialogue.typeDelay, currentDialogue.speaker.typingSound));


        Dialogue.CharacterEmotion rileyEmotion;
        Dialogue.CharacterEmotion npcEmotion;


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

            rileyEmotion = currentDialogue.speakerEmotion;
            npcEmotion = currentDialogue.listenerEmotion;
            rileyProfile.myCharacter = currentDialogue.speaker;
            NPCprofile.myCharacter = currentDialogue.listener;


            textObject.alignment = TextAlignmentOptions.TopLeft;

            rileyProfile.FadeInColor();

            NPCprofile.FadeOutColor();

        }
        else
        {
            rileyEmotion = currentDialogue.listenerEmotion;
            npcEmotion = currentDialogue.speakerEmotion;
            NPCprofile.myCharacter = currentDialogue.speaker;
            rileyProfile.myCharacter = currentDialogue.listener;



            textObject.alignment = TextAlignmentOptions.TopLeft;
            rileyProfile.FadeOutColor();

            NPCprofile.FadeInColor();

        }

        rileyProfile.profileImage.sprite = rileyProfile.SpriteFromMood(rileyEmotion);
        NPCprofile.profileImage.sprite = NPCprofile.SpriteFromMood(npcEmotion);


        speakerNameObject.text = currentDialogue.speaker.name;

        if (currentDialogue.nextDialogue == null)
        {
            if (currentDialogue.choiceButtons.Length > 0)
            {
                nextButtonObject.gameObject.SetActive(false);

                for (int i = 0; i < currentDialogue.choiceButtons.Length; i++)
                {
                    GameObject _choiceButton = Instantiate(choiceButton);
                    _choiceButton.transform.SetParent(choiceButtonLayout.transform);
                    _choiceButton.GetComponent<ChoiceButton>().textObject.text = currentDialogue.choiceButtons[i].buttonText;
                    _choiceButton.GetComponent<ChoiceButton>().myId = i;
                }
                choiceButtonsExist = true;
                return;
            }
        }

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
