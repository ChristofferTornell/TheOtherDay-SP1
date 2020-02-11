using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractivity : MonoBehaviour
{
    [SerializeField] private string interactionButton;

    private Interactable interactableObject = null;

    private void Start()
    {
        if (interactionButton.Length == 0) { Debug.LogError("The useButton string is empty"); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            interactableObject = collision.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            interactableObject = null;
        }
    }

    void Update()
    {
        // Interact with the Object using the useButton
        if (interactableObject && Input.GetButtonDown(interactionButton))
        {
            //Debug.Log("Doing something with " + interactableObject.name);

            if (interactableObject.Door)
            {
                SavedPositions.NewPosition(GameController.currentScene, new Vector2(interactableObject.transform.position.x, gameObject.transform.position.y));
            }

            interactableObject.Interact();
            // Do something with the object
        }
    }
}
