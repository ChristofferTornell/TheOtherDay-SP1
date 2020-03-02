using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Examine : MonoBehaviour
{
    public Items item;
    public Image sprite;
    public TextMeshProUGUI description;
    public new TextMeshProUGUI name;

    private void OnEnable()
    {
        sprite.sprite = item.icon;
        description.text = item.description;
        name.text = item.myName;
    }
}
