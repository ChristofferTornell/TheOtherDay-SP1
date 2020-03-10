using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackClubEvents : SceneEvents
{
    public Interactable door;
    public Interactable doorToFoyer;
    public int rileyCharIndex;
    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            Debug.Log("Make riley drunk");
            GlobalData.instance.charaters[rileyCharIndex].isDrunk = true;
        }
        if (eventIndex == 2)
        {
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
        if(eventIndex == 5)
        {
            Debug.Log("Make riley sober");
            GlobalData.instance.charaters[rileyCharIndex].isDrunk = false;
        }
    }
}
