using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPreview : MonoBehaviour
{
    private CharacterData character;
    private string message;
    public TextMeshProUGUI text;
    public int previewLenght = 25;

    void Start()
    {
        character = GetComponentInParent<MessageSquare>().character;
        message = character.sms[character.sms.Length - 1];
        if(message.Length >= 25)
        {
            string preview = message.Remove(previewLenght, message.Length - previewLenght);
            text.text = preview + "...";
        }
        else
        {
            text.text = message;
        }
    }
}
