using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnInteract;

    public void Interact()
    {
        OnInteract.Invoke();
    }

    public void IE_Pickup(GameObject objectToPickup)
    {
        // Add object to Inventoy and remove it from the ground
    }

    public void IE_OpenDoor(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
