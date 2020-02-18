using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Items : ScriptableObject
{
    public Sprite sprite;
    public string myName;
    public bool useable = false;
    [TextArea(3, 7)]
    public string description;

}
