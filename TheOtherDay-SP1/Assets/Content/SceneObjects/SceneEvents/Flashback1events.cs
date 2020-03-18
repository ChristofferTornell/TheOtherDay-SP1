using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashback1events : SceneEvents
{
    public GameObject erin;
    public SpriteRenderer erinSpriteRenderer;
    private bool walkTrigger;
    private float walkCounter;
    public AnimationClip walkingAnimation;
    public Animator erinAnimator;
    public float erinWalkSpeed = 1f;
    public float walkingDuration = 1f;
    public float alphaDecrease = 0.01f;
    public Dialogue postWalkDialogue;

    public override void PlayEvent(int eventIndex)
    {
        if (eventIndex == 1)
        {
            Debug.Log("Play erin animation");
            erinAnimator.Play(walkingAnimation.name);
            erin.GetComponent<BoxCollider2D>().enabled = false;
            walkTrigger = true;
            
            GameController.pause = true;
        }
        if (eventIndex == 2)
        {
            objectAppear.SetActive(true);
        }
    }
    private float alpha = 1f;
    void Update()
    {
        if (walkTrigger)
        {
            alpha -= alphaDecrease;
            erinSpriteRenderer.color = new Color(1f, 1f, 1f, alpha);
            walkCounter += Time.deltaTime;
            erin.transform.Translate(-Vector2.right * erinWalkSpeed * Time.deltaTime);
            if (walkCounter >= walkingDuration)
            {
                
                GameController.pause = false;
                walkTrigger = false;

                DialogueManager.instance.EnterDialogue(postWalkDialogue);
                Destroy(erin.gameObject);
            }
        }
    }
}
