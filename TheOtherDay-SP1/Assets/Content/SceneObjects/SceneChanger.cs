﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [System.Serializable]
    public class SceneAndTime
    {
        [SerializeField] private string flashbackName = null;
        [SerializeField] private FlashbackTime flashbackTime = null;

        public FlashbackTime GetSceneTime(string sceneName)
        {
            if (sceneName == flashbackName)
            {
                return flashbackTime;
            }
            else return null;
        }
    }

    public static UnityAction<SceneChanger> onChange = delegate { };

    [SerializeField] private float sceneChangeDelay = 1f;
    public static SceneChanger instance;

    [FMODUnity.EventRef] public string enterFlashbackSound;
    [FMODUnity.EventRef] public string exitFlashbackSound;

    public List<SceneAndTime> flashbackTimeList = new List<SceneAndTime>();

    private Color fadeInColor;
    private Color fadeOutColor;

    private bool flashbackTransition = false;
    private FlashbackTime flashbackTime = null;
    
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

    private void Start()
    {
        onChange += OnChange;
    }

    void OnChange(SceneChanger sceneChanger)
    {
        Debug.Log("Changing scene");
    }

    private IEnumerator CoChangeScene(string sceneName)
    {
        onChange(this);

        if (flashbackTransition)
        {          
            for (int i = 0; i < flashbackTimeList.Count; i++)
            {
                if (flashbackTimeList[i].GetSceneTime(sceneName))
                {
                    flashbackTime = flashbackTimeList[i].GetSceneTime(sceneName);
                }
            }
        }

        if (sceneName == "CityPresent")
        {
            fadeInColor = Color.gray;
            fadeOutColor = Color.gray;
        }

        else
        {
            fadeInColor = Color.black;
            fadeOutColor = Color.black;
        }

        if (sceneName != "Main Menu") SceneTransition.instance.TRAN_FadeIn(fadeInColor);

        yield return new WaitForSeconds(sceneChangeDelay);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("Loading scene: " + sceneName);
        operation.allowSceneActivation = false;

        // When faded in:
        // Play flashbackTransition after it comes into screen from animation
        // When clock is done, reverse the animation and then change scen

        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                if (flashbackTransition)
                {
                    if (flashbackTime)
                    {
                        FlashbackTransitionClock.instance.StartCoroutine(FlashbackTransitionClock.instance.TRAN_StartTransition(flashbackTime));
                    }
                    else { Debug.LogError("SceneChanger - Can't find flashbackTime from: " + sceneName); }

                    if (FlashbackTransitionClock.instance.done)
                    {
                        Debug.Log("Activating scene: " + sceneName);
                        operation.allowSceneActivation = true;
                        SceneTransition.instance.TRAN_FadeOut(fadeOutColor);
                    }
                }

                if (!flashbackTransition)
                {
                    Debug.Log("Activating scene: " + sceneName);
                    operation.allowSceneActivation = true;
                    SceneTransition.instance.TRAN_FadeOut(fadeOutColor);
                }
            }

            yield return null;
        }

        //Play fade out when the operation is coplmete

        //if (operation.isDone) SceneTransition.instance.TRAN_FadeOut(fadeOutColor);

        //SceneManager.LoadScene(sceneName);

        yield return null;
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("SceneChanger - Changing Scene to: " + sceneName);
        flashbackTransition = false;
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
    }

    public void EnterFlashback(string sceneName)
    {
        // Save current time into DigitalClockObject

        Debug.Log("SceneChanger - Entering flashback: " + sceneName);
        FMODUnity.RuntimeManager.PlayOneShot(enterFlashbackSound);
        flashbackTransition = true;
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
    }

    public void ExitFlashback(string sceneName)
    {
        // Get saved time from DigitalClockObject

        Debug.Log("SceneChanger - Returning to present: " + sceneName);
        FMODUnity.RuntimeManager.PlayOneShot(exitFlashbackSound);
        GlobalData.instance.stage++;
        Notes.instance.ProgressToNextEntry();
        flashbackTransition = true;
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
    }
}
