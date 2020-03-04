using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueContainer
{
    public Dialogue dialogue = null;
    public Dialogue dialogueSpoken = null;
    public bool hasSpoken = false;
    public Dialogue dialogueFlashback = null;
    public Dialogue dialogueFlashbackSpoken = null;
    public bool hasSpokenFlashback = false;
}
