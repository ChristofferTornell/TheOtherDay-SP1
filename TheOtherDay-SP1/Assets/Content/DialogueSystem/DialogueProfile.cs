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
            if (GlobalData.instance.flashBack)
            {
                return myCharacter.dialogueImageFlashbackNormal;
            }
            else
            {
                return myCharacter.dialogueImagePresentNormal;
            }
        }
        if (mood == Dialogue.CharacterEmotion.happy)
        {
            if (GlobalData.instance.flashBack)
            {
                return myCharacter.dialogueImageFlashbackHappy;
            }
            else
            {
                return myCharacter.dialogueImagePresentHappy;
            }
        }
        if (mood == Dialogue.CharacterEmotion.sad)
        {
            if (GlobalData.instance.flashBack)
            {
                return myCharacter.dialogueImageFlashbackSad;
            }
            else
            {
                return myCharacter.dialogueImagePresentSad;
            }

        }
        if (mood == Dialogue.CharacterEmotion.angry)
        {
            if (GlobalData.instance.flashBack)
            {
                return myCharacter.dialogueImageFlashbackAngry;
            }
            else
            {
                return myCharacter.dialogueImagePresentAngry;
            }

        }
        Debug.Log("Error, mood doesnt have sprite");
        return myCharacter.dialogueImageFlashbackNormal;


    }
}
