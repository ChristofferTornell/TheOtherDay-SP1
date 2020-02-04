using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InMessage : MonoBehaviour
{
    private CharacterData character;
    public Image image;
    public TextMeshProUGUI text;
    public TextMeshProUGUI sms;


    void Start()
    {
        character = GetComponentInParent<MessageSquare>().character;
        image.sprite = character.contactImage;
        text.text = character.name;
        sms.text = character.sms[0];
    }
}
