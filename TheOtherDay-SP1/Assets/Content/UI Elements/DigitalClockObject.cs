using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DigitalClockObject : ScriptableObject
{
    public float seconds;
    public float minutes;
    public float hours;

    [HideInInspector] public float flashbackMinutes;
    [HideInInspector] public float flashbackHours;

    private void Awake()
    {
        seconds = 0f;
        minutes = 0f;
        hours = 13f;
    }

    public void ConvertFlashbackTime(float m1, float m2, float h1, float h2)
    {
        seconds = 0;
        flashbackMinutes = (m2 * 10) + m1;
        flashbackHours = (h2 * 10) + h1;
    }
}
