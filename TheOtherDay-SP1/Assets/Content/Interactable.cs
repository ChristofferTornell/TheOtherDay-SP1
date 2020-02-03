using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [Space]
    public float sceneChangeDelay = 2f;
    [Header("Events")]
    public UnityEvent OnInteract;

    public void Interact()
    {
        OnInteract.Invoke();
    }

    IEnumerator ChangeScene(string sceneName)
    {
        // Scene change effect(s) can be put here
        // --------------------------------------

        yield return new WaitForSeconds(sceneChangeDelay);
        SceneManager.LoadScene(sceneName);

        yield return null;
    }

    public void IE_Pickup(GameObject objectToPickup)
    {
        // Add object to Inventoy and remove it from the ground
    }

    public void IE_ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeScene(sceneName));
    }
}
