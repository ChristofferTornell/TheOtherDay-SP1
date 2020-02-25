﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using FMODUnity;

public class Interactable : MonoBehaviour
{
    public bool savePlayerPosition = false;
    public bool mouseInteraction = false;
    public bool pickupItem = false;
    public bool OneTime = false;
    public CursorSprite hoverCursor = CursorSprite.BigHand;
    [Space]
    [SerializeField] private float sceneChangeDelay = 1f;
    public CharacterData characterdata = null;
    public Items itemData = null;
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

        if (!mouseInteraction)
        {
            onInteract.Invoke();
            if (OneTime) { DestroyThis(); }
        }
        else { Debug.Log(gameObject.name + "can only be interacted with using the mouse"); }
    }

    private void OnMouseEnter()
    {
        if (mouseInteraction && !DialogueManager.dialogueActive)
        {
            gameController.ChangeCursor(hoverCursor);
        }
        // Play highlight effects on the object
    }

    private void OnMouseExit()
    {
        if (mouseInteraction)
        {
            gameController.ResetCursor();
        }
    }

    private void OnMouseDown()
    {
        if (mouseInteraction && !DialogueManager.dialogueActive)
        {
            Debug.Log("Interacting with " + gameObject.name + " using mouse");
            onInteract.Invoke();
            if (GlobalData.instance.flashBack && pickupItem)
            {
                Inventory.instance.INV_AddItem(itemData);
            }
            if (OneTime) { DestroyThis(); }
        }
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }

    private IEnumerator ChangeScene(string sceneName)
    {
        // Scene change effect(s) can be put here
        // --------------------------------------

        yield return new WaitForSeconds(sceneChangeDelay);

        SceneManager.LoadScene(sceneName);

        yield return null;
    }

    // IE_ = Interactivity Event
    public void IE_ChangeScene(string sceneName)
    {
        Debug.Log("Interactable - Changing Scene to: " + sceneName);
        StartCoroutine(ChangeScene(sceneName));
        GameController.Pause(true);
    }

    public void IE_EnterFlashback(string sceneName)
    {
        Debug.Log("Interactable - Entering flashback: " + sceneName);
        StartCoroutine(ChangeScene(sceneName));
        GameController.Pause(true);
        GlobalData.instance.flashBack = true;
    }

    public void IE_ExitFlashback(string sceneName)
    {
        Debug.Log("Interactable - Returning to present: " + sceneName);
        StartCoroutine(ChangeScene(sceneName));
        GameController.Pause(true);
        GlobalData.instance.flashBack = false;
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
}
