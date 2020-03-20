using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DigitalClockObject : ScriptableObject
{
    public float seconds;
    public float minutes;
    public float hours;

    private void Awake()
    {
        seconds = 0f;
        minutes = 0f;
        hours = 13f;
    }
}
