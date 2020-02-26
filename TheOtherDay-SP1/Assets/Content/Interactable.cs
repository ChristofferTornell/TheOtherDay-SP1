using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using FMODUnity;

public class Interactable : MonoBehaviour
{
    public bool savePlayerPosition = false;
    public bool OneTime = false;
    public CursorSprite hoverCursor = CursorSprite.BigHand;
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
    }

    public void Interact()
    {
        onInteract.Invoke();
        if (OneTime) { DestroyThis(); }

        else { Debug.Log(gameObject.name + "can only be interacted with using the mouse"); }
    }

    private void OnMouseEnter()
    {
        if (!DialogueManager.dialogueActive)
        {
            gameController.ChangeCursor(hoverCursor);
        }
        // Play highlight effects on the object
    }

    private void OnMouseExit()
    {

        gameController.ResetCursor();

    }

    private void OnMouseDown()
    {
        Debug.Log("Pressed on interactable");
        if (!DialogueManager.dialogueActive)
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


    // Needs testing
    public void IE_PlayAudio()
    {
        // Play interaction audio here <---
        Debug.Log("Interactable - Playing audio: " + " ->Audio source here<-");
        //FMODUnity.RuntimeManager.PlayOneShot(interactSoundEvent); SOUND IMPLEMENTATION

    }

    private void IE_PlayScreenEffect()
    {
        // PH, make public when done
    }

    public void IE_PlayDialogue(Dialogue dialogue)
    {
        // Play the dialogue here
    }

    public void IE_GiveItem()
    {
        if (PuzzleMouse.itemOnMouse != null)
        {
            GetComponent<PuzzleMaster>().RecieveItem();
        }
    }
}
