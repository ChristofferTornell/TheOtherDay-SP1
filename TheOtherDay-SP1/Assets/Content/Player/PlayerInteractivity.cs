using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractivity : MonoBehaviour
{
    [SerializeField] private string interactionButton;

    [HideInInspector] public List<Interactable> interactables = new List<Interactable>();
    public GameObject interactUI;

    private void Start()
    {
        if (interactionButton.Length == 0) { Debug.LogError("PlayerInteractivity - The interactionButton string is empty"); }
        SceneChanger.onChange += OnSceneChange;
    }

    public void OnSceneChange(SceneChanger sceneChanger)
    {
        interactables.Clear();
        UpdateInteractUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            if (collision.GetComponent<Interactable>().isInteractableWithSpace)
            {
                interactables.Add(collision.GetComponent<Interactable>());
                UpdateInteractUI();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            if (collision.GetComponent<Interactable>().isInteractableWithSpace)
            {
                interactables.Remove(collision.GetComponent<Interactable>());
                UpdateInteractUI();
            }
        }
    }

    private void CheckInteractUI()
    {
        bool updateUI = false;
        foreach (Interactable _interactable in interactables)
        {
            if (_interactable.isInteractableWithSpace)
            {
                updateUI = true;
            }
        }
        if (updateUI == true)
        {
            UpdateInteractUI();
        }
    }
    private void UpdateInteractUI()
    {
        if (interactables.Count > 0)
        {
            interactUI.SetActive(true);

        }
        else
        {
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
        if (interactables.Count > 0 && Input.GetButtonDown(interactionButton))
        {
            if (!DialogueManager.dialogueActive)
            {
                //Debug.Log("Doing something with " + interactables[0].name);

                if (interactables[0].savePlayerPosition)
                {
                    SavedPositions.NewPosition(GameController.currentScene, new Vector2(interactables[0].transform.position.x, gameObject.transform.position.y));
                }

                interactables[0].Interact();
                // Do something with the object
            }
        }
    }
}
