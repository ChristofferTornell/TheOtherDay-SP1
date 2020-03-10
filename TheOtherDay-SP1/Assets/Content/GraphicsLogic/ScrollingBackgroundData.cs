using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScrollingBackgroundData", menuName = "ScriptableObjects/ScrollingBackgroundData", order = 4)]

public class ScrollingBackgroundData : ScriptableObject
{
    public float scrollingSpeed = 0.05f;
}
