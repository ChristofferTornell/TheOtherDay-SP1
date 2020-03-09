using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackClubEvents : SceneEvents
{
    public Interactable door;

    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            Debug.Log("Play Riley puking animation");
        }
        if (eventIndex == 2)
        {
            Debug.Log("Unlock door");
            door.lockedByEvent = false;
        }
    }
}
