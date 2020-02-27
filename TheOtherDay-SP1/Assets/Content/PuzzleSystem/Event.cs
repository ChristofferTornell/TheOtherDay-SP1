using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : ScriptableObject
{
    public bool eventComplete = false;

    [Header("Conditions")]
    [SerializeField] private List<Event> eventConditions = new List<Event>();
    [SerializeField] private List<Items> itemConditions = new List<Items>();

    public void CompleteEvent()
    {
        eventComplete = true;
    }

    public bool CheckIfDone()
    {
        for (int i = 0; i < eventConditions.Count; i++)
        {
            if (!eventConditions[i].eventComplete)
            {
                Debug.Log("Event - Event: " + eventConditions[i].name + " is not completed");
                return false;
            }
        }

        for (int i = 0; i < itemConditions.Count; i++)
        {

        }

        eventComplete = true;
        return eventComplete;
        // Go thruogh all conditions, if all are satisfied: EventComplete = true 
    }
}
