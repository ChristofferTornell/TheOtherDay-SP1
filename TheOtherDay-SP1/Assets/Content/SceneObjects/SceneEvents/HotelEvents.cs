using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelEvents : SceneEvents
{
    public Dialogue openPhoneDialogue = null;
    public Dialogue closePhoneDialogue = null;
    public Interactable hotelDoor;

    private bool event2Cleared = false;
    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            //show screen
        }
        if (eventIndex == 2 && !event2Cleared)
        {
            DialogueManager.instance.EnterDialogue(openPhoneDialogue);
            event2Cleared = true;
        }
        if (eventIndex == 3)
        {
            DialogueManager.instance.EnterDialogue(closePhoneDialogue);
            hotelDoor.lockedByEvent = false;
        }
    }

}
