using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractivity : MonoBehaviour
{
    [SerializeField] private string useButton = "Fire1";

    private GameObject interactableObject = null;

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
            Debug.Log("Doing something with " + interactableObject.name);
            // Do something with the object
        }
    }
}
