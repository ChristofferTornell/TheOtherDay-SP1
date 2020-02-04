using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //public CharacterProfile character;
    public enum CharacterEmotion
    {
        normal,
        happy,
        sad
    };

    public CharacterEmotion characterEmotion = CharacterEmotion.normal;

    public TextMeshProUGUI textObject;

    [TextArea(15, 20)]
    public string dialog = "";

    //public ChoiceButton[] choiceButtons = null;
    public Button nextButtonObject = null;
    public Dialogue nextDialogue = null;
}
