using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class LogEntry
{
    public string message;
    public bool complete = false;
    public bool visible = false;
    public int index;
    public TextMeshProUGUI textObj;
}
