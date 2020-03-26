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
    public static float minutes;
    public static float hours;

    [Header("Display")]
    public TextMeshProUGUI hoursDisplay = null;
    public TextMeshProUGUI minutesDisplay = null;
    public Color displayColor;

    [Header("Bad Ending")]
    [SerializeField] private Dialogue badEndingDialogue = null;
    [SerializeField] private float dialogueDelay = 0.5f;
    [SerializeField] private float pickupPhoneAnimationDelay = 1;
    [FMODUnity.EventRef] [SerializeField] private string alarmSoundEvent;
    private bool changingTime = false;
    private float timeChangeAmount = 0;
    private bool triggerEnd = false;

    private void Start()
    {
        if (timeFactor <= 0) { timeFactor = 1; }

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

        Debug.Log("Flashback (clock):" + FlashbackTransitionClock.instance.flashback);

        if (!FlashbackTransitionClock.instance.flashback)
        {
            DisplayPresentTime();
        }

        if (FlashbackTransitionClock.instance.flashback)
        {
            DisplayStartingTime();
        }

        SceneChanger.onChange += OnSceneChange;
    }

    public void ConvertFlashbackTime(float m1, float m2, float h1, float h2)
    {
        minutes = (m2 * 10) + m1;
        hours = (h2 * 10) + h1;
    }

    private void DisplayStartingTime()
    {
        ConvertFlashbackTime(FlashbackTransitionClock.instance.startingTime.minute1, FlashbackTransitionClock.instance.startingTime.minute2,
            FlashbackTransitionClock.instance.startingTime.hour1, FlashbackTransitionClock.instance.startingTime.hour2);
        Debug.Log("DigitalClockScript - Displaying starting/flashback time: " + hours + minutes);
    }

    private void DisplayPresentTime()
    {
        ConvertFlashbackTime(FlashbackTransitionClock.instance.presentTime.minute1, FlashbackTransitionClock.instance.presentTime.minute2,
            FlashbackTransitionClock.instance.presentTime.hour1, FlashbackTransitionClock.instance.presentTime.hour2);
        Debug.Log("DigitalClockScript - Displaying present time: " + hours + minutes);
    }

    private void Update()
    {
        if (!GameController.pause && !GlobalData.instance.flashBack && GlobalData.instance.clockActivated) { seconds += Time.deltaTime * timeFactor; }

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
        if (hours >= 18 && !GlobalData.instance.flashBack && !triggerEnd && !GameController.pause)
        {
            triggerEnd = true;
            PlayBadEndingEvents();
        }
    }

    void SaveTime()
    {
        FlashbackTransitionClock.instance.SavePresentTime(minutes, hours);
        Debug.Log("Saved present time");
    }

    void OnSceneChange(SceneChanger changer)
    {
        if (!FlashbackTransitionClock.instance.flashback)
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

    public void ActivateClock()
    {
        GlobalData.instance.clockActivated = true;
    }
    private void PlayBadEndingEvents()
    {
        GameController.pause = true;
        FMODUnity.RuntimeManager.PlayOneShot(alarmSoundEvent);
        Invoke("PlayPickupPhoneAnimation", pickupPhoneAnimationDelay);
    }
    private void PlayPickupPhoneAnimation()
    {
        PlayerMovement.playerInstance.animator.SetBool("phone", true);
        Invoke("PlayBadEndingDialogue", dialogueDelay);
    }
    private void PlayBadEndingDialogue()
    {
        DialogueManager.instance.EnterDialogue(badEndingDialogue);
    }
}
