using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractivity : MonoBehaviour
{
    [SerializeField] private string useButton = "Fire1";

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
        if (interactableObject && Input.GetButtonDown(useButton))
        {
            //interactableObject.GetComponent<Interactable>().OnInteract;
            Debug.Log("Doing something with " + interactableObject.name);
            // Do something with the object
        }
    }
}
