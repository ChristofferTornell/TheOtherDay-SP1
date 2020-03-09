using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashback1events : SceneEvents
{

    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            Debug.Log("Playing erin animation");
        }
        if (eventIndex == 2)
        {
            objectAppear.SetActive(true);
        }
    }
}
