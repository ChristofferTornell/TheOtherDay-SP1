﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashback2events : MonoBehaviour
{
    public Dialogue initialDialogue;
    public static Flashback2events instance;
    public GameObject objectAppear;
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

        if (objectAppear != null)
        {
            objectAppear.SetActive(false);
        }
        Invoke("InitDialogue", dialogueDelay);
    }

    public void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            objectAppear.SetActive(true);
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
