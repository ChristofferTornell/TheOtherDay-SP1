using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackClubEvents : MonoBehaviour
{
    public static FlashbackClubEvents instance;
    public Dialogue initialDialogue;
    public float dialogueDelay = 0.2f;
    public Interactable door;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    public void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            Debug.Log("Play Riley puking animation");
        }
        if (eventIndex == 2)
        {
            Debug.Log("Unlock door");
            door.lockedByEvent = false;
        }
    }

    void InitDialogue()
    {
        if (initialDialogue != null)
        {
            Debug.Log("Dialogue manager: " + DialogueManager.instance);
            DialogueManager.instance.EnterDialogue(initialDialogue);
        }
    }

}
