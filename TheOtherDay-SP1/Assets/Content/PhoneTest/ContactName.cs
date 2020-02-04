using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContactName : MonoBehaviour
{
    public Global global;
    public TextMeshProUGUI text;
    public string character;

    private void Start()
    {
        int ID = checkCharacter(character);
        text.text = global.Names[ID];
    }

    int checkCharacter(string character)
    {
        if (character == "Riley")
        {
            return 0;
        }

        else
        {
            return 0;
        }
    }
}
