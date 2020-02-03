using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractEvent : UnityEvent<string, GameObject> { }

public class Interactable : MonoBehaviour
{

    public InteractEvent OnInteract;
    // What to have here?

    // On interact, do a list of events
    // Ability to add events in inspcetor

    public void Interact()
    {

    }

    public void TestEvent()
    {

    }
}
