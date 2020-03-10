using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackClubEvents : SceneEvents
{
    public Interactable door;
    public Interactable doorToFoyer;
    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            Debug.Log("Make riley drunk");
        }
        if (eventIndex == 2)
        {
            Debug.Log("Unlock tofoyer door");
            doorToFoyer.lockedByEvent = false;
        }
        if (eventIndex == 3)
        {
            Debug.Log("Play Riley puking animation");
        }
        if (eventIndex == 4)
        {
            Debug.Log("Unlock door");
            door.lockedByEvent = false;
        }
    }
}
