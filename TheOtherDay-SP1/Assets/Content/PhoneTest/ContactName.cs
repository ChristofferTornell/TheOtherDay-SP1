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
        if(character == "Riley")
        {
            text.text = global.Names[0];
        }
    }
}
