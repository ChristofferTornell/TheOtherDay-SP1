using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InMessage : MonoBehaviour
{
    private CharacterData character;
    public TextMeshProUGUI sms;


    void Start()
    {
        character = GetComponentInParent<MessageSquare>().character;
        sms.text = character.sms[0]; //Index får tas från progressionsystemet på något sätt, vilka sms som ska visas
    }
}
