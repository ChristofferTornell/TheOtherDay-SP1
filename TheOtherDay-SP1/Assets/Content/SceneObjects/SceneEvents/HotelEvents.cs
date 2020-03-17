using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelEvents : SceneEvents
{
    public Dialogue openPhoneDialogue = null;
    public Dialogue closePhoneDialogue = null;
    public Interactable hotelDoor;

    private bool event2Cleared = false;

    private bool hasProgressed = false;
    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            //show screen
        }

        else if (eventIndex == 10 && !event2Cleared)
        {
            DialogueManager.instance.EnterDialogue(openPhoneDialogue);
            event2Cleared = true;
        }
        else if (eventIndex == 11)
        {
            if (hasViewedErinConvo && !hasProgressed)
            {
                hasProgressed = true;
                DialogueManager.instance.EnterDialogue(closePhoneDialogue);
                hotelDoor.lockedByEvent = false;
            }
        }
        else if (eventIndex == 12)
        {
            if (!hasViewedErinConvo)
            {
                Notes.instance.ProgressToNextEntry();
                hasViewedErinConvo = true;
            }
        }
    }
    public override void CustomStart()
    {
        Debug.Log("check visisted");
        if (sceneData.hasVisited)
        {
            Debug.Log("has visisted");
            hotelDoor.lockedByEvent = false;
        }
    }
}
