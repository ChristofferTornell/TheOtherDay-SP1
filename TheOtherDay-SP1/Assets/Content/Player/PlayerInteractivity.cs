using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractivity : MonoBehaviour
{
    [SerializeField] private string interactionButton;

    private Interactable interactableObject = null;
    public GameObject interactUI;

    private void Start()
    {
        if (interactionButton.Length == 0) { Debug.LogError("PlayerInteractivity - The interactionButton string is empty"); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            interactableObject = collision.GetComponent<Interactable>();
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            interactableObject = null;
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
        if (interactableObject && Input.GetButtonDown(interactionButton))
        {
            Debug.Log("Dialogue active: " + DialogueManager.dialogueActive);

            if (DialogueManager.dialogueActive && currentDialogue.noChoiceDialogue == null)
            {
                Debug.Log("Go to next dialogue via space");
                DialogueManager.instance.currentDialogue = currentDialogue.nextDialogue;
                DialogueManager.instance.dialogueBoxUI.TakeNewDialogue();
            }
            else if (!DialogueManager.dialogueActive)
            {
                Debug.Log("Doing something with " + interactableObject.name);

                if (interactableObject.savePlayerPosition)
                {
                    SavedPositions.NewPosition(GameController.currentScene, new Vector2(interactableObject.transform.position.x, gameObject.transform.position.y));
                }

                interactableObject.Interact();
                // Do something with the object
            }
        }
    }
}
