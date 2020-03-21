using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [HideInInspector] public Dialogue currentDialogue = null;
    public TextMeshProUGUI textObject = null;
    public TextMeshProUGUI leftNameTextObject = null;
    public TextMeshProUGUI rightNameTextObject = null;
    public GameObject leftNamePlate;
    public GameObject rightNamePlate;
    public Button nextButtonObject = null;
    public GameObject choiceButtonLayout = null;

    public DialogueProfile rileyProfile = null;
    public DialogueProfile NPCprofile = null;
    private bool rileySpeaking = true;

    public GameObject choiceButton;
    private bool choiceButtonsExist = false;
    private bool choiceTimerInitiated = false;
    private float choiceTimerCounter = 0;
    private bool typingFinished = false;
    public TextMeshProUGUI choiceTimerTextObject = null;
    private List<GameObject> choiceButtons = new List<GameObject>();
    [SerializeField] private string interactionButton = "Interact Button";

    public float universalTypeDelayMultiplier = 1;
    private float typeSoundCounter;
    public float typeSoundDelay = 0.1f;
    private bool typeSoundReady;

    public void InitializeDialogueUI()
    {
        dialogueEnded = false;
        currentDialogue = DialogueManager.instance.currentDialogue;
        ResetChoiceTimer();
        UpdateDialogueUI();
    }

    public void TakeNewDialogue()
    {
        ResetChoiceTimer();
        ResetDialogueUI();
        CheckExistingDialogue();
        UpdateDialogueUI();
    }

    private void ResetChoiceTimer()
    {
        choiceTimerCounter = currentDialogue.TimeLimitSeconds;
        choiceTimerInitiated = false;
        typingFinished = false;
        choiceTimerTextObject.gameObject.SetActive(false);
    }

    public void GoToNextDialogue()
    {
        DialogueManager.instance.currentDialogue = currentDialogue.nextDialogue;
        DialogueManager.instance.dialogueBoxUI.TakeNewDialogue();
    }
    private void Update()
    {
        if (DialogueManager.dialogueActive && currentDialogue.choiceButtons.Length == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            GoToNextDialogue(); 
        }

        if (!typeSoundReady)
        {
            typeSoundCounter += Time.deltaTime;
            if (typeSoundDelay < typeSoundCounter)
            {
                typeSoundReady = true;
                typeSoundCounter = 0;
            }
        }


        if (currentDialogue.TimeLimitSeconds > 0 && choiceTimerInitiated == false && typingFinished)
        {
            //choiceTimerTextObject.gameObject.SetActive(true);
            choiceTimerInitiated = true;
            choiceTimerCounter = currentDialogue.TimeLimitSeconds;

        }
        if (choiceTimerInitiated)
        {
            if (choiceTimerCounter <= 0f)
            {
                Debug.Log("You ran out of time!");
                ResetChoiceTimer();
                DialogueManager.instance.currentDialogue = currentDialogue.noChoiceDialogue;
                DialogueManager.instance.dialogueBoxUI.TakeNewDialogue();
                return;
            }
            
            choiceTimerCounter -= Time.deltaTime;
            choiceTimerCounter = Mathf.Clamp(choiceTimerCounter, 0f, Mathf.Infinity);
            choiceTimerTextObject.text = string.Format("{0:00.00}", choiceTimerCounter);
           
            
        }
    }

    IEnumerator AutotypeText()
    {
        textObject.font = currentDialogue.speaker.font;
        textObject.color = currentDialogue.speaker.color;
        textObject.fontStyle = FontStyles.Normal;
        if (currentDialogue.italic)
        {
            textObject.fontStyle = FontStyles.Italic;
        }
        foreach (Message _message in currentDialogue.messages)
        {
            FMODUnity.RuntimeManager.PlayOneShot(_message.messageSound); //SOUND IMPLEMENTATION
            /*
            if (_message.bold)
            {
                textObject.fontStyle = FontStyles.Bold;
            }
            if (_message.italic)
            {
                textObject.fontStyle = FontStyles.Italic;
            }
            if (_message.useAlternateColor)
            {
                textObject.color = _message.alternateColor;
            }
            */
            for (int i = 0; i < _message.text.Length; i++)
            {
                textObject.text += _message.text[i];
                //textObject.text = _message.text.Substring(0, i + 1);

                if (typeSoundReady)
                {
                    FMODUnity.RuntimeManager.PlayOneShot(currentDialogue.speaker.typingSound);
                    typeSoundReady = false;
                }

                yield return new WaitForSeconds(_message.typeDelay * universalTypeDelayMultiplier);
            }
        }
        if (currentDialogue.nextDialogue == null)
        {
            if (currentDialogue.choiceButtons.Length > 0)
            {
                for (int i = 0; i < currentDialogue.choiceButtons.Length; i++)
                {
                    GameObject _choiceButton = Instantiate(choiceButton);
                    _choiceButton.transform.SetParent(choiceButtonLayout.transform);
                    _choiceButton.GetComponent<ChoiceButton>().textObject.text = currentDialogue.choiceButtons[i].buttonText;
                    _choiceButton.GetComponent<ChoiceButton>().myId = i;
                    choiceButtons.Add(_choiceButton);
                }
                choiceButtonsExist = true;
            }
        }
        typingFinished = true;
        if (currentDialogue.choiceButtons.Length == 0)
        {
            nextButtonObject.gameObject.SetActive(true);

        }
    }

    public void CheckSceneTrigger()
    {
        if (currentDialogue.triggerScene != "")
        {
            if (currentDialogue.enterFlashback)
            {
                SceneChanger.instance.EnterFlashback(currentDialogue.triggerScene);
            }
            if (currentDialogue.exitFlashback)
            {
                SceneChanger.instance.ExitFlashback(currentDialogue.triggerScene);
            }
        }
    }
    private bool dialogueEnded;
    void CheckExistingDialogue()
    {
        StopAllCoroutines();

        if (currentDialogue.flashbackEvent != 0)
        {

            SceneEvents.instance.CheckEvent(currentDialogue.flashbackEvent);
        }

        if (choiceButtonsExist)
        {
            foreach (Transform child in choiceButtonLayout.transform)
            {
                choiceButtons.Remove(child.gameObject);
                Destroy(child.gameObject);
            }
        }
        if (currentDialogue.nextDialogue == null)
        {
            if (currentDialogue.choiceButtons.Length == 0)
            {
                CheckSceneTrigger();
                ResetDialogueUI();
                dialogueEnded = true;
                DialogueManager.instance.ExitDialogue();
                return;
            }

        }
    }
    public void UpdateDialogueUI()
    {
        if (dialogueEnded)
        {
            return;
        }
        nextButtonObject.gameObject.SetActive(false);

        if (DialogueManager.instance.currentDialogue != null)
        {
            currentDialogue = DialogueManager.instance.currentDialogue;
        }
        //nextButtonObject.GetComponent<NextDialogueButton>().UpdateDialogue();
        if (PlayerMovement.playerInstance != null)
        {
            PlayerMovement.playerInstance.GetComponent<PlayerInteractivity>().UpdateDialogue();
        }
        //FMODUnity.RuntimeManager.PlayOneShot(currentDialogue.messageVocalizationSound); IMPLEMENT AUDIO
        if (currentDialogue.changeReputation != 0)
        {
            GlobalData.instance.reputation += currentDialogue.changeReputation;
        }
        if (currentDialogue.item != null)
        {
            Inventory.instance.INV_AddItem(currentDialogue.item);
        }

        Dialogue.CharacterEmotion rileyEmotion;
        Dialogue.CharacterEmotion npcEmotion;

        if (currentDialogue.listener == null)
        {
            NPCprofile.profileImage.gameObject.SetActive(false);
        }
        else
        {
            NPCprofile.profileImage.gameObject.SetActive(true);

        }

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
            leftNamePlate.SetActive(true);
            rightNamePlate.SetActive(false);

            rileyEmotion = currentDialogue.speakerEmotion;
            rileyProfile.myCharacter = currentDialogue.speaker;

            if (currentDialogue.listener != null)
            {
                NPCprofile.myCharacter = currentDialogue.listener;
                NPCprofile.FadeOutColor();

            }
            npcEmotion = currentDialogue.listenerEmotion;




            textObject.alignment = TextAlignmentOptions.TopLeft;

            rileyProfile.FadeInColor();

            leftNameTextObject.text = currentDialogue.speaker.name;
            leftNameTextObject.color = currentDialogue.speaker.color;

        }
        else
        {

            leftNamePlate.SetActive(false);
            rightNamePlate.SetActive(true);
            rileyEmotion = currentDialogue.listenerEmotion;
            npcEmotion = currentDialogue.speakerEmotion;
            NPCprofile.myCharacter = currentDialogue.speaker;
            rileyProfile.myCharacter = currentDialogue.listener;


            textObject.alignment = TextAlignmentOptions.TopLeft;
            rileyProfile.FadeOutColor();

            NPCprofile.FadeInColor();
            rightNameTextObject.text = currentDialogue.speaker.name;
            rightNameTextObject.color = currentDialogue.speaker.color;

        }

        rileyProfile.profileImage.sprite = rileyProfile.SpriteFromMood(rileyEmotion);

        if (currentDialogue.listener != null)
        {
            NPCprofile.profileImage.sprite = NPCprofile.SpriteFromMood(npcEmotion);
        }

        if (isActiveAndEnabled)
        {
            StartCoroutine(AutotypeText());
        }


    }

    public void ResetDialogueUI()
    {
        textObject.text = "";
        //currentDialogue = null;
        //textObject.text = "";
        //nextButtonObject = null;
        //leftProfile = null;
        // rightProfile = null;
    }

}
