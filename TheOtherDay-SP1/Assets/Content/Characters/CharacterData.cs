using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterData : ScriptableObject
{
    public new string name;
    public Sprite contactImage;
    public Sprite dialogueImageNormal;
    public Sprite dialogueImageHappy;
    public Sprite dialogueImageSad;

    public TMPro.TMP_FontAsset font;
    public Color color;
    [FMODUnity.EventRef] public string typingSound;

    [TextArea(15,20)]
    public string[] sms;

}
