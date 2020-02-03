using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactImage : MonoBehaviour
{
    public Global global;
    public Image image;
    public string character;


    private void Start()
    {
        if (character == "Riley")
        {
            image.sprite = global.ContactImages[0];
        }
    }
}
