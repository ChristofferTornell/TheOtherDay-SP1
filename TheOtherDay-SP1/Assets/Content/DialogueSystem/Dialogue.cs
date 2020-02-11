﻿using System.Collections;
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
        sad
    };

    [Header ("Customization")]
    public CharacterData speaker;
    public CharacterEmotion speakerEmotion = CharacterEmotion.normal;
    [FMODUnity.EventRef] public string messageVocalizationSound;

    public CharacterData listener;
    public CharacterEmotion listenerEmotion = CharacterEmotion.normal;

    [TextArea(15, 20)]
    public string message = "";
    public float typeDelay = 0.01f;

    [Header ("Insertables")]
    public Dialogue nextDialogue = null;
    public float TimeLimitSeconds = 0;
    public ChoiceButtonBlueprint[] choiceButtons = null;
}

