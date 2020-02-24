using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CallSquare : MonoBehaviour
{
    public string time = "00:00";
    public bool missed;
    public CharacterData character;
    public Image ContactImage;
    public Sprite[] typeSprite;
    public Image type;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI nameText;


    void Start()
    {
        ContactImage.sprite = character.contactImage;
        nameText.text = character.name;
        if(missed == false)
        {
            type.sprite = typeSprite[0];
        }
        else
        {
            type.sprite = typeSprite[1];
        }
        timeText.text = time;
    }
}
