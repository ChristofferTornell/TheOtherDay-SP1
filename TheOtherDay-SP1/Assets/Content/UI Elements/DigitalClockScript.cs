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
    [Space]
    [SerializeField] private float seconds;
    public float minutes;
    public float hours;

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

        seconds = digitalClockObject.seconds;
        minutes = digitalClockObject.minutes;
        hours = digitalClockObject.hours;

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

        SceneManager.sceneUnloaded += OnSceneUnloaded;
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

    void SaveTime()
    {
        digitalClockObject.seconds = seconds;
        digitalClockObject.minutes = minutes;
        digitalClockObject.hours = hours;
        FlashbackTransitionClock.instance.SavePresentTime(minutes, hours);
        Debug.Log("Saved present time");
    }

    void OnSceneUnloaded(Scene scene)
    {
        // Unsure if this will work as intended
        if (!GlobalData.instance.flashBack)
        {
            SaveTime();
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
