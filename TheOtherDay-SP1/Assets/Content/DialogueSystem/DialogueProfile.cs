using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueProfile : MonoBehaviour
{
    public Image profileImage;
    public CharacterData myCharacter;
    public Color listenerFadeColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    public Color speakerActiveColor = new Color(1f, 1f, 1f, 1f);

    public void FadeOutColor()
    {
        profileImage.color = listenerFadeColor;
    }

    public void FadeInColor()
    {
        profileImage.color = speakerActiveColor;
    }

    public Sprite SpriteFromMood(Dialogue.CharacterEmotion mood)
    {
        if (mood == Dialogue.CharacterEmotion.normal)
        {
            return myCharacter.dialogueImageFlashbackNormal;
            
        }
        if (mood == Dialogue.CharacterEmotion.happy)
        {
            return myCharacter.dialogueImageFlashbackHappy;

        }
        if (mood == Dialogue.CharacterEmotion.sad)
        {
            return myCharacter.dialogueImageFlashbackSad;

        }
        Debug.Log("Error, mood doesnt have sprite");
        return myCharacter.dialogueImageFlashbackNormal;


    }
}
