using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackPizzeriaEvents : SceneEvents
{
    public string goodEndingScene;
    public string weirdEndingScene;

    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            //Riley drop ring animation
        }
        if (eventIndex == 2)
        {
          
            if (GlobalData.instance.reputation < 0)
            {
                SceneChanger.instance.ChangeScene(weirdEndingScene);
            }
            else
            {
                SceneChanger.instance.ChangeScene(goodEndingScene);
            }
            
        }
    }
}
