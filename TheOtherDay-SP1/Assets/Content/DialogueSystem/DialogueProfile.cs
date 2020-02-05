using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueProfile : MonoBehaviour
{
    public Image profileImage;
    public TextMeshProUGUI profileName;
    public Image profileNameBox;

    public Color listenerFadeColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    public Color speakerActiveColor = new Color(1f, 1f, 1f, 1f);

    public void FadeOutColor()
    {
        profileImage.color = listenerFadeColor;
        profileNameBox.color = listenerFadeColor;
        profileName.color = listenerFadeColor;
    }

    public void FadeInColor()
    {
        profileImage.color = speakerActiveColor;
        profileNameBox.color = speakerActiveColor;
        profileName.color = speakerActiveColor;
    }
}
