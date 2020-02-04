using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageSquare : MonoBehaviour
{
    public CharacterData character;
    public Image image;
    public TextMeshProUGUI text;
    public TextMeshProUGUI sms;


    void Start()
    {
        image.sprite = character.contactImage;
        text.text = character.name;
        sms.text = character.sms[0];
    }
}
