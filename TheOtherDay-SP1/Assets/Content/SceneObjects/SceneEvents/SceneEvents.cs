﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEvents : MonoBehaviour
{
    public int sceneDataIndex;
    private SceneData sceneData;
    public static SceneEvents instance;
    public GameObject objectAppear;
    public float dialogueDelay = 0.2f;
    public Dialogue initialDialogue;

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
        sceneData = GlobalData.instance.sceneDataList[sceneDataIndex];
        if (objectAppear != null)
        {
            objectAppear.SetActive(false);
        }
        Invoke("InitDialogue", dialogueDelay);
    }
    void InitDialogue()
    {
        if (initialDialogue != null)
        {
            Debug.Log("Dialogue manager: " + DialogueManager.instance);
            DialogueManager.instance.EnterDialogue(initialDialogue);
        }
    }
    public virtual void PlayEvent(int eventIndex)
    {

    }
    void OnDestroy()
    {
        sceneData.hasVisited = true;
    }
}
