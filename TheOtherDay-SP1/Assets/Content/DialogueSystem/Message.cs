using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Message
{
    [TextArea] public string text;
    public float typeDelay = 0.01f;
    //public bool bold;
    //public bool italic;
    //public bool useAlternateColor;
    //public Color alternateColor;
    [FMODUnity.EventRef] public string messageSound;

}
