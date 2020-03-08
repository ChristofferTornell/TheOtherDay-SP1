using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelEvents : MonoBehaviour
{
    public Dialogue initialDialogue;
    public static HotelEvents instance;
    public float dialogueDelay = 0.2f;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    void Start()
    {
        Invoke("InitDialogue", dialogueDelay);
    }

    public void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            //show screen
        }
        if (eventIndex == 2)
        {
            //trigger phone dialogue
        }
    }

    void InitDialogue()
    {
        if (initialDialogue != null)
        {
            DialogueManager.instance.EnterDialogue(initialDialogue);
        }
    }
}
