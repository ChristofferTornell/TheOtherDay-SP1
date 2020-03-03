using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterData : ScriptableObject
{
    public new string name;
    [TextArea] public string description;

    public Sprite contactImage;

    public Sprite dialogueImageFlashbackNormal;
    public Sprite dialogueImageFlashbackHappy;
    public Sprite dialogueImageFlashbackSad;

    public Sprite dialogueImagePresentNormal;
    public Sprite dialogueImagePresentHappy;
    public Sprite dialogueImagePresentSad;

    public TMPro.TMP_FontAsset font;
    public Color color;
    [FMODUnity.EventRef] public string typingSound;

    public DialogueContainer[] dialogues;

    [TextArea(15,20)]
    public string[] sms;

}
