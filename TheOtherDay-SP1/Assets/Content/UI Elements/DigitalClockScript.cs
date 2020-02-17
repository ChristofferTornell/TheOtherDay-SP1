using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DigitalClockScript : MonoBehaviour
{
    [Tooltip("The digital clock ScriptableObject for saving the time on")] public DigitalClockObject digitalClockObject = null;

    [Header("Time")]
    public float timeFactor = 10f;
    [SerializeField] private float seconds;
    public float minutes;
    public float hours;

    [Header("Display")]
    public TextMeshProUGUI hoursDisplay = null;
    public TextMeshProUGUI minutesDisplay = null;
    public Color displayColor;
    public int displayColorAlpha = 255;

    private bool changingTime = false;
    private float timeChangeAmount = 0;

    private void Start()
    {
        if (timeFactor <= 0) { timeFactor = 1; }

        seconds = digitalClockObject.seconds;
        minutes = digitalClockObject.minutes;
        hours = digitalClockObject.hours;

        displayColor.a = displayColorAlpha;
        hoursDisplay.color = displayColor;
        minutesDisplay.color = displayColor;

        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void Update()
    {
        //if (!GameController.pause) { seconds += Time.deltaTime * timeFactor; }

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
            minutes ++;
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
    }

    void OnSceneUnloaded(Scene scene)
    {
        minutes += timeChangeAmount;
        digitalClockObject.minutes = minutes;
    }

    public void ChangeTime(float minutes)
    {
        if (!changingTime)
        {
            timeChangeAmount = minutes;
            changingTime = true;
        }
    }

    private void LateUpdate()
    {
        digitalClockObject.seconds = seconds;
        digitalClockObject.minutes = minutes;
        digitalClockObject.hours = hours;
    }
}
