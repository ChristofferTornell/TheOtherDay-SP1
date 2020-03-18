using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafePresentEvents : SceneEvents
{
    public override void PlayEvent(int eventIndex)
    {
        if(eventIndex == 1)
        {
            Debug.Log("talked to jason present");
            GlobalData.instance.stage++;
            Notes.instance.ProgressToNextEntry();
        }
    }
}
