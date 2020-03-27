using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackPizzeriaEvents : SceneEvents
{
    public AnimationClip pickUpAnimation;
    public Animator playerAnimator;

    private bool pickUpTrigger;
    private float pickUpCounter;
    public Dialogue postPickUpDialogue;

    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            playerAnimator = FindObjectOfType<PlayerMovement>().animator;
            playerAnimator.Play(pickUpAnimation.name);
            pickUpTrigger = true;
            GameController.pause = true;
        }
    }
    void Update()
    {
        if (pickUpTrigger)
        {
            pickUpCounter += Time.deltaTime;
            if (pickUpCounter >= pickUpAnimation.length)
            {
                GameController.pause = false;
                pickUpTrigger = false;
                DialogueManager.instance.EnterDialogue(postPickUpDialogue);
            }
        }
    }
}
