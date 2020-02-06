using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using FMODUnity;

public class Interactable : MonoBehaviour
{
    public bool mouseInteraction = false;
    [Space]
    [SerializeField] private float sceneChangeDelay = 1f;
    public CharacterData characterdata = null;
    [Header("Events")]
    [SerializeField] private UnityEvent OnInteract;

    public void Interact()
    {
        if (!mouseInteraction)
        {
            OnInteract.Invoke();
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
            OnInteract.Invoke();
        }
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
    public void IE_Pickup(GameObject objectToPickup)
    {
        Debug.Log("Interactable - Picking up: " + objectToPickup);
        // Add object to Inventoy and remove it from the ground
    }

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
