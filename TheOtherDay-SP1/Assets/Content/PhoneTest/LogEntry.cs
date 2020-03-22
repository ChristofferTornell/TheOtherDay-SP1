using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class LogEntry
{
    public string message;
    [HideInInspector] public bool complete = false;
    [HideInInspector] public bool visible = false;
    [HideInInspector] public int index;
    [HideInInspector] public TextMeshProUGUI textObj;
}
