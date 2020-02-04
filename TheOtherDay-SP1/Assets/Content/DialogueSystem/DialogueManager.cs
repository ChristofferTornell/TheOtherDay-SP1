using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    //public Dialogue currentDialogue = null;
    //private bool dialogueActive = false;

    public static DialogueManager instance;

    void Awake()
    {
        instance = this;
    }
}
