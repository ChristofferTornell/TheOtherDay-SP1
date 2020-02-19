using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : ScriptableObject
{
    public bool EventComplete = false;

    [Header("Conditions")]
    [SerializeField] private List<Event> eventConditions = new List<Event>();
    [SerializeField] private List<Items> itemConditions = new List<Items>();

    public void CheckIfDone()
    {
        // Go thruogh all conditions, if all are satisfied: EventComplete = true 
    }
}
