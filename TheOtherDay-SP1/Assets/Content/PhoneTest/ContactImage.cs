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
        int ID = checkCharacter(character);
        image.sprite = global.ContactImages[ID];
    }

    int checkCharacter(string character)
    {
        if(character == "Riley")
        {
            return 0;
        }

        else
        {
            return 0;
        }
    }
}
