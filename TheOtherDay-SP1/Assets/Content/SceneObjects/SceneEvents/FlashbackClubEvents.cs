using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackClubEvents : SceneEvents
{
    public AnimationClip pukingAnimation;
    public Animator playerAnimator;
    public Interactable door;
    public Interactable doorToFoyer;
    public int rileyCharIndex;
    private bool pukeTrigger;
    private float pukeCounter;

    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            Debug.Log("Make riley drunk");
            GlobalData.instance.charaters[rileyCharIndex].isDrunk = true;
        }
        else if (eventIndex == 2)
        {
            doorToFoyer.lockedByEvent = false;
        }
        else if (eventIndex == 3)
        {
            Debug.Log("Play Riley puking animation");
            playerAnimator = FindObjectOfType<PlayerMovement>().animator;
            playerAnimator.Play(pukingAnimation.name);
            pukeTrigger = true;
            GameController.pause = true;
        }
        else if (eventIndex == 4)
        {
            Debug.Log("Unlock door");
            door.lockedByEvent = false;
        }
        else if (eventIndex == 5)
        {
            Debug.Log("Make riley sober");
            GlobalData.instance.charaters[rileyCharIndex].isDrunk = false;
        }
    }
    void Update()
    {
        if (pukeTrigger)
        {
            pukeCounter += Time.deltaTime;
            if(pukeCounter >= pukingAnimation.length)
            {
                GameController.pause = false;
                pukeTrigger = false;
                //DialogueManager.instance.EnterDialogue(postPukeDialogue);
            }
        }
    }
}
