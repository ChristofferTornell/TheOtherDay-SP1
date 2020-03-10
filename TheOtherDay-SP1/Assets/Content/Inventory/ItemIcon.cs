using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    public Image myImage;

    public void UpdateSprite(Sprite _sprite)
    {
        myImage.sprite = _sprite;
    }
}
