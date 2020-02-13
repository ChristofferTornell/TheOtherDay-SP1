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
    public bool OneTime = false;
    [Space]
    [SerializeField] private float sceneChangeDelay = 1f;
    public CharacterData characterdata = null;
    [Header("Events")]
    [SerializeField] private UnityEvent onInteract; // Byter man namn på denna kommer alla existerande interactables att förlora sina events

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
        // Play highlight effects on the object
    }

    private void OnMouseDown()
    {
        if (mouseInteraction)
        {
            Debug.Log("Interacting with " + gameObject.name + " using mouse");
            onInteract.Invoke();
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

    // Needs testing
    public void IE_PlayAudio(AudioClip audioClip)
    {
        // Play interaction audio here <---
        Debug.Log("Interactable - Playing audio: " + " ->Audio source here<-");
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
