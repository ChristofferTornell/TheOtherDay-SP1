using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    public Color startColor = new Color(1f, 1f, 1f, 1f);
    public Color enterColor;
    public Color pressColor;
    private Image image;
    [SerializeField] private UnityEvent onClick; // Byter man namn på denna kommer alla existerande interactables att förlora sina events
    private bool mouseOverImage = false;
    private bool hasBeenPressed = false;

    void Start()
    {
        image = GetComponent<Image>();
        startColor = image.color;
    }
    void OnMouseEnter()
    {
        Debug.Log("mouse enter");
        mouseOverImage = true;
        image.color = enterColor;
    }
    void OnMouseExit()
    {
        mouseOverImage = false;
        image.color = startColor;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && mouseOverImage)
        {
            if (!hasBeenPressed)
            {
                onClick.Invoke();
                hasBeenPressed = true;
            }
            image.color = pressColor;
        }
    }
}
