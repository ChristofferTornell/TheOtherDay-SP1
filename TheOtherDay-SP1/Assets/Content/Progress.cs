using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Progress Tracker", menuName = "Progress tracker (only one is needed)")]
public class Progress : ScriptableObject
{
    public int stage;
}