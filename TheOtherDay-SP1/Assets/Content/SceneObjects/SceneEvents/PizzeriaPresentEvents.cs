using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzeriaPresentEvents : SceneEvents
{
    public string goodEndingScene;
    public string weirdEndingScene;
    public float minReputationForWeirdEnding = -2;
    public Dialogue stage6initDialogue;

    public override void CustomStart()
    {
        if(GlobalData.instance.stage >= 6)
        {
            DialogueManager.instance.EnterDialogue(stage6initDialogue);
            sceneData.hasVisited = false;
        }
    }
    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            //play Hand in pocket animation
        }
        if (eventIndex == 2)
        {
            if (GlobalData.instance.reputation <= minReputationForWeirdEnding)
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
