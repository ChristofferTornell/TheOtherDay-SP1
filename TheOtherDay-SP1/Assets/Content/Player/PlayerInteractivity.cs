using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractivity : MonoBehaviour
{
    [SerializeField] private string interactionButton;

    private List<Interactable> interactables = new List<Interactable>();
    public GameObject interactUI;

    private void Start()
    {
        if (interactionButton.Length == 0) { Debug.LogError("PlayerInteractivity - The interactionButton string is empty"); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            interactables.Add(collision.GetComponent<Interactable>());
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            interactables.Remove(collision.GetComponent<Interactable>());
            interactUI.SetActive(false);
        }
    }

    [HideInInspector] public Dialogue currentDialogue;
    public void UpdateDialogue()
    {
        currentDialogue = DialogueManager.instance.currentDialogue;
    }

    void Update()
    {
        // Interact with the Object using the useButton
        if (interactables[0] && Input.GetButtonDown(interactionButton))
        {
            if (!DialogueManager.dialogueActive)
            {
                Debug.Log("Doing something with " + interactables[0].name);

                if (interactables[0].savePlayerPosition)
                {
                    SavedPositions.NewPosition(GameController.currentScene, new Vector2(interactables[0].transform.position.x, gameObject.transform.position.y));
                }

                interactables[0].Interact();
                // Do something with the object
            }
        }
        if (DialogueManager.dialogueActive)
        {
            Debug.Log("currentDialogue: " + currentDialogue);
        }


    }
}
