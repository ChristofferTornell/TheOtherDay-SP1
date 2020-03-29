using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzeriaPresentEvents : SceneEvents
{
    public string goodEndingScene;
    public string weirdEndingScene;
    public float minReputationForWeirdEnding = -2;
    public Dialogue stage6initDialogue;

    [Space]
    public AnimationClip checkPocketAnimation;
    public Animator playerAnimator;

    private bool checkPocketTrigger;
    private float checkPocketCounter;
    public Dialogue postCheckPocketDialogue;
    public float checkPocketPauseDuration = 3f;

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
            if (eventIndex == 1)
            {
                playerAnimator = FindObjectOfType<PlayerMovement>().animator;
                playerAnimator.Play(checkPocketAnimation.name);
                checkPocketTrigger = true;
                GameController.pause = true;
            }
        }
        else if (eventIndex == 2)
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
    void Update()
    {
        if (checkPocketTrigger)
        {
            checkPocketCounter += Time.deltaTime;
            if (checkPocketCounter >= checkPocketAnimation.length + checkPocketPauseDuration)
            {
                GameController.pause = false;
                checkPocketTrigger = false;
                DialogueManager.instance.EnterDialogue(postCheckPocketDialogue);
            }
        }
    }
}
