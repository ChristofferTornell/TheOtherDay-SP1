using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using FMODUnity;

public class Interactable : MonoBehaviour
{
    public bool savePlayerPosition = false;
    public bool changeCursorOnHover = false;
    public bool isInteractableWithSpace = true;
    public bool hideOnStart = false;
    public int unlockedOnStage = 0;
    public bool lockedByEvent;
    public Items requiredItem;
    public Items lockedData;
    public Dialogue lockedDialogue;
    public int charIndex = 0;
    public CursorSprite hoverCursor = CursorSprite.Hand;
    [Space]
    [Header("Audio")]
    [FMODUnity.EventRef] public string interactSoundEvent;

    [Header("Events")]
    [SerializeField] private UnityEvent onInteract; // Byter man namn på denna kommer alla existerande interactables att förlora sina events
    [SerializeField] private UnityEvent onMouseInteract;
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        if (hideOnStart)
        {
            //gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        if (lockedData != null && unlockedOnStage > GlobalData.instance.stage)
        {
            DescriptionUI.instance.ExamineItem(lockedData);
            return;
        }
        if (requiredItem != null)
        {
            if (!Inventory.instance.INV_FindItem(requiredItem))
            {
                if (lockedData != null)
                {
                    DescriptionUI.instance.ExamineItem(lockedData);
                    return;
                }
                if (lockedDialogue != null)
                {
                    DialogueManager.instance.EnterDialogue(lockedDialogue);
                    return;
                }
            }
        }
        if (lockedByEvent)
        {
            DialogueManager.instance.EnterDialogue(lockedDialogue);
            return;
        }
        if (Phone.Pulled)
        {
            return;
        }
        onInteract.Invoke();
        /*
        if (OneTime) { DestroyThis(); }

        else { Debug.Log(gameObject.name + "can only be interacted with using the mouse"); }
        */
    }

    private void OnMouseEnter()
    {
        if (!DialogueManager.dialogueActive && !Phone.Pulled)
        {
            PuzzleMouse.overInteractable = true;

            if (changeCursorOnHover)
            {
                if (!PuzzleMouse.itemOnMouse)
                {
                    PuzzleMouse.hoverText.text = gameObject.name;
                }

                gameController.ChangeCursor(hoverCursor);
            }
        }

        // Play highlight effects on the object
    }

    private void OnMouseExit()
    {
        gameController.ResetCursor();
        PuzzleMouse.overInteractable = false;
        PuzzleMouse.hoverText.text = null;
    }

    private void OnMouseDown()
    {
        //Debug.Log("Pressed on interactable");
        if (!DialogueManager.dialogueActive && !Phone.Pulled)
        {
            onMouseInteract.Invoke();
        }
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }

    // IE_ = Interactivity Event
    public void IE_ChangeScene(string sceneName)
    {
        SceneChanger.instance.ChangeScene(sceneName);
    }

    public void IE_EnterFlashback(string sceneName)
    {
        SceneChanger.instance.EnterFlashback(sceneName);
    }

    public void IE_ExitFlashback(string sceneName)
    {
        SceneChanger.instance.ExitFlashback(sceneName);
    }

    public void IE_DestroySelf()
    {
        Destroy(gameObject);
    }


    // Needs testing
    public void IE_PlayAudio()
    {
        // Play interaction audio here <---
        Debug.Log("Interactable - Playing audio: " + " ->Audio source here<-");
        FMODUnity.RuntimeManager.PlayOneShot(interactSoundEvent);

    }

    private void IE_PlayScreenEffect()
    {
        // PH, make public when done
    }

    public void IE_GiveItem()
    {
        if (PuzzleMouse.itemOnMouse != null)
        {
            GetComponent<PuzzleMaster>().RecieveItem();
        }
    }

    public void IE_PlayDialogueSpecific(Dialogue dialogue)
    {
        DialogueManager.instance.EnterDialogue(dialogue);
    }
    public void IE_PlayDialogue()
    {
        CharacterData charData = GlobalData.instance.charaters[charIndex];

        Dialogue _initDialogue = null;
        int _stage = GlobalData.instance.stage;

        if (!GlobalData.instance.flashBack)
        {
            if (!charData.dialogues[_stage].hasSpoken)
            {
                _initDialogue = charData.dialogues[_stage].dialogue;
            }
            else
            {
                _initDialogue = charData.dialogues[_stage].dialogueSpoken;
            }
        }
        else
        {
            if (!charData.dialogues[_stage].hasSpokenFlashback)
            {
                _initDialogue = charData.dialogues[_stage].dialogueFlashback;
            }
            else
            {
                _initDialogue = charData.dialogues[_stage].dialogueFlashbackSpoken;
            }
        }
        if (GetComponent<PuzzleMaster>() != null)
        {
            PuzzleMaster pMaster = GetComponent<PuzzleMaster>();
            if (pMaster.PuzzleClear())
            {
                _initDialogue = pMaster.clearDialogue;
                DialogueManager.instance.EnterDialogue(_initDialogue);
                return;
            }
        }
        if (_initDialogue != null)
        {
            if (GlobalData.instance.flashBack)
            {
                charData.dialogues[_stage].hasSpokenFlashback = true;
            }
            else
            {
                charData.dialogues[_stage].hasSpoken = true;
            }

            DialogueManager.instance.EnterDialogue(_initDialogue);
        }

    }

}
