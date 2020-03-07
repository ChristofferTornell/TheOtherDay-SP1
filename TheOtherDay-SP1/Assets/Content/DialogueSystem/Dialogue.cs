using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/DialogueTemplate", order = 2)]

public class Dialogue : ScriptableObject
{
    public enum CharacterEmotion
    {
        normal,
        happy,
        sad,
        angry
    };

    [Header ("Customization")]
    public CharacterData speaker;
    public CharacterEmotion speakerEmotion = CharacterEmotion.normal;

    public CharacterData listener;
    public CharacterEmotion listenerEmotion = CharacterEmotion.normal;

    public int changeReputation;
    public bool italic;
    public Message[] messages;
    [Header("Insertables")]
    public bool initial;
    public Dialogue nextDialogue = null;
    [Space]
    public string triggerScene;
    public bool enterFlashback = false;
    public bool exitFlashback = false;
    [Space]
    public Items item;
    public int flashbackEvent;
    [Space]
    public float TimeLimitSeconds = 0;
    public Dialogue noChoiceDialogue = null;
    public ChoiceButtonBlueprint[] choiceButtons = null;
}

