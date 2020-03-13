using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    // Player exits scene, play fade in animation
    // Player enter a new scene, play fade out animation.
    // ability to change the color of the fading and duration?

    public Image panelImage;
    [Header("Transition Stuf")]
    public Animator animator = null;
    public AnimationClip fadeInAnimation = null;
    public AnimationClip fadeOutAnimation = null;

    public DigitalClockScript digitalClock = null;

    public static SceneTransition instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TRAN_FadeIn(Color color)
    {
        panelImage.color = color;
        animator.Play(fadeInAnimation.name);
    }

    public void TRAN_FadeOut(Color color)
    {
        panelImage.color = color;
        animator.Play(fadeOutAnimation.name);
    }
}
