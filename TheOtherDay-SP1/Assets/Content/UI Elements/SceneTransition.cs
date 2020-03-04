using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Image panelImage;
    [Header("Transition Stuf")]
    public Animator animator = null;
    public AnimationClip fadeInAnimation = null;
    public Color fadeInColor;
    public AnimationClip fadeOutAnimation = null;
    public Color fadeOutColor;

    private void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded; 
        SceneManager.sceneLoaded += OnSceneLoaded; 

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void TRAN_FadeIn()
    {
        panelImage.color = fadeInColor;
        animator.Play(fadeInAnimation.name);
    }

    public void TRAN_FadeOut()
    {
        panelImage.color = fadeOutColor;
        animator.Play(fadeOutAnimation.name);
    }

    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log(gameObject.scene.name + " unloaded");
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        animator.Play(fadeOutAnimation.name);
        Debug.Log(scene.name + " loaded");
    }
}
