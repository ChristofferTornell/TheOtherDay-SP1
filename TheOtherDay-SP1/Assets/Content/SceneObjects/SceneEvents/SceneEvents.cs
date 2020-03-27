using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEvents : MonoBehaviour
{
    public int sceneDataIndex;
    protected SceneData sceneData;
    public static SceneEvents instance;

    public GameObject objectAppear;
    public float dialogueDelay = 0.2f;
    public Dialogue initialDialogue;

    public bool hasViewedErinConvo = false;

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
        CustomStart();
        if (sceneData.hasVisited)
        {
            return;
        }
        if (objectAppear != null)
        {
            objectAppear.SetActive(false);
        }
        Invoke("InitDialogue", dialogueDelay * 0);
    }
    void InitDialogue()
    {
        if (initialDialogue != null)
        {
            DialogueManager.instance.EnterDialogue(initialDialogue);
        }
    }
    public void CheckEvent(int eventIndex)
    {
        if (sceneData.hasVisited)
        {
            return;
        }
        PlayEvent(eventIndex);
    }
    public virtual void PlayEvent(int eventIndex)
    {

    }
    void OnDestroy()
    {
        if (sceneData != null)
        {
            sceneData.hasVisited = true;
        }
    }
    public virtual void CustomStart()
    {

    }
}
