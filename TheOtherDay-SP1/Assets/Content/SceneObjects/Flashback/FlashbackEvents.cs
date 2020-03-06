using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackEvents : MonoBehaviour
{
    public Dialogue initialDialogue;
    public static FlashbackEvents instance;
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

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InitDialogue", dialogueDelay);
    }

    // Update is called once per frame
    public void ShowObject()
    {
        objectAppear.SetActive(true);
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
