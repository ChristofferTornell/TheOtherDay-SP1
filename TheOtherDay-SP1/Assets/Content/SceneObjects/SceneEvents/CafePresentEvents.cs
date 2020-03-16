using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafePresentEvents : SceneEvents
{
    public override void PlayEvent(int eventIndex)
    {
        if(eventIndex == 1)
        {
            GlobalData.instance.stage++;
            Notes.instance.ProgressToNextEntry();
        }
    }
}
