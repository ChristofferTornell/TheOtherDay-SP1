using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [Space]
    public float sceneChangeDelay = 1f;
    [Header("Events")]
    public UnityEvent OnInteract;
    public AudioSource interactSound = null;

    public void Interact()
    {
        if (interactSound) interactSound.playOnAwake = false;
        OnInteract.Invoke();
    }

    IEnumerator ChangeScene(string sceneName)
    {
        // Scene change effect(s) can be put here
        // --------------------------------------

        if (interactSound) { interactSound.Play(); }

        yield return new WaitForSeconds(sceneChangeDelay);
        SceneManager.LoadScene(sceneName);

        yield return null;
    }

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
        if (interactSound)
        {
            Debug.Log("Interactable - Playing AudioClip: " + audioClip);
            interactSound.clip = audioClip;
            interactSound.Play();
        }
        else { Debug.LogError(gameObject.name + ": Cannot play Audio, missing AudioSource"); }
    }

    private void IE_PlayScreenEffect()
    {
        // PH, make public when done
    }

}
