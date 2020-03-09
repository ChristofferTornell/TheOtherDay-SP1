using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashback2events : SceneEvents
{
    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            objectAppear.SetActive(true);
        }
    }
}
