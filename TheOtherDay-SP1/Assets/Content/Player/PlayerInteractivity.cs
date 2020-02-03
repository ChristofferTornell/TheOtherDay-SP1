using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractivity : MonoBehaviour
{
    [SerializeField] private string useButton;

    private GameObject interactableObject = null;

    private void Start()
    {
        if (useButton.Length == 0) { Debug.LogError("The useButton string is empty"); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>())
        {
            interactableObject = collision.gameObject;
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
        if (interactableObject && Input.GetButtonDown(useButton))
        {
            interactableObject.GetComponent<Interactable>().Interact();
            Debug.Log("Doing something with " + interactableObject.name);
            // Do something with the object
        }
    }
}
