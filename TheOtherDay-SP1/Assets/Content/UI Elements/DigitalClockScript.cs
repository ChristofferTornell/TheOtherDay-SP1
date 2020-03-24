﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DigitalClockScript : MonoBehaviour
{
    [Tooltip("The digital clock ScriptableObject for saving the time on")] public DigitalClockObject digitalClockObject = null;

    [Header("Time")]
    public float timeFactor = 10f;
    [Space]
    [SerializeField] private float seconds;
    public static float minutes;
    public static float hours;

    [Header("Display")]
    public TextMeshProUGUI hoursDisplay = null;
    public TextMeshProUGUI minutesDisplay = null;
    public Color displayColor;

    [Header("Bad Ending")]
    public string badEndingScene = "BadEnding";

    private bool changingTime = false;
    private float timeChangeAmount = 0;
    private bool triggerEnd = false;

    private void Start()
    {
        if (timeFactor <= 0) { timeFactor = 1; }

        if (GlobalData.instance.flashBack == true)
        {
            DisplayFlashbackTime();
        }

        if (GlobalData.instance.flashBack == false)
        {
            DisplayPresentTime();
        }

        hoursDisplay.color = displayColor;
        minutesDisplay.color = displayColor;

        if (hours > 9)
        {
            hoursDisplay.text = hours + ":";
        }
        else { hoursDisplay.text = "0" + hours + ":"; }

        if (minutes > 9)
        {
            minutesDisplay.text = minutes.ToString();
        }
        else { minutesDisplay.text = "0" + minutes.ToString(); }

        Debug.Log("Flashback:" + GlobalData.instance.flashBack);
        StartCoroutine(Delayer());

        SceneChanger.onChange += OnSceneUnloaded;
    }

    IEnumerator Delayer()
    {
        yield return new WaitForSeconds(0.3f);

        if (GlobalData.instance.flashBack == true)
        {
            DisplayFlashbackTime();
        }

        if (GlobalData.instance.flashBack == false)
        {
            DisplayPresentTime();
        }

        yield return null;
    }

    public void ConvertFlashbackTime(float m1, float m2, float h1, float h2)
    {
        minutes = (m2 * 10) + m1;
        hours = (h2 * 10) + h1;
    }

    private void DisplayPresentTime()
    {
        //seconds = digitalClockObject.seconds;
        //minutes = digitalClockObject.minutes;
        //hours = digitalClockObject.hours;
        Debug.Log("DigitalClockScript - Displaying present time");
        ConvertFlashbackTime(FlashbackTransitionClock.instance.presentTime.minute1, FlashbackTransitionClock.instance.presentTime.minute2,
            FlashbackTransitionClock.instance.presentTime.hour1, FlashbackTransitionClock.instance.presentTime.hour2);
    }
    private void DisplayFlashbackTime()
    {
        Debug.Log("DigitalClockScript - Displaying flashback time");
        ConvertFlashbackTime(FlashbackTransitionClock.instance.currentFlashbackTime.minute1, FlashbackTransitionClock.instance.currentFlashbackTime.minute2,
            FlashbackTransitionClock.instance.currentFlashbackTime.hour1, FlashbackTransitionClock.instance.currentFlashbackTime.hour2);
    }

    private void Update()
    {
        if (!GameController.pause && !GlobalData.instance.flashBack) { seconds += Time.deltaTime * timeFactor; }

        if (hours > 9)
        {
            hoursDisplay.text = hours + ":";
        }
        else { hoursDisplay.text = "0" + hours + ":"; }

        if (minutes > 9)
        {
            minutesDisplay.text = minutes.ToString();
        }
        else { minutesDisplay.text = "0" + minutes.ToString(); }

        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }
        if (minutes >= 60)
        {
            hours++;
            minutes = 0;
        }
        if (hours >= 24)
        {
            hours = 0;
        }
        if (hours == 18 && !GlobalData.instance.flashBack && !triggerEnd)
        {
            SceneChanger.instance.ChangeScene(badEndingScene);
            triggerEnd = true;
        }
    }

    //void ApplyToObject()
    //{
    //    digitalClockObject.seconds = seconds;
    //    digitalClockObject.minutes = minutes;
    //    digitalClockObject.hours = hours;
    //}

    void SaveTime()
    {
        FlashbackTransitionClock.instance.SavePresentTime(minutes, hours);
        Debug.Log("Saved present time");
    }

    void OnSceneUnloaded(SceneChanger changer)
    {
        // Unsure if this will work as intended
        if (!GlobalData.instance.flashBack)
        {
            //SaveTime();
        }
    }

    public void ChangeTime(float minutes)
    {
        if (!changingTime)
        {
            timeChangeAmount = minutes;
            changingTime = true;
        }
    }
}
