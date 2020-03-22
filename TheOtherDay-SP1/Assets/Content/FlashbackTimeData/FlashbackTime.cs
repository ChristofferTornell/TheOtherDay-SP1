using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FlashbackTime : ScriptableObject
{
    [Header("The digital time (h2 h1 : m2 m1)")]
    public float minute1;
    public float minute2;
    public float hour1;
    public float hour2;
    [Space]
    [Tooltip("Whether this time is during a flashback or not, which determines if the clock goes backwards or not")]
    public bool flashback;
}
