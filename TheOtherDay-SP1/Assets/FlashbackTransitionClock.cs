using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlashbackTransitionClock : MonoBehaviour
{
    [HideInInspector] public bool flashback = false;
    public static FlashbackTransitionClock instance;
    public float speedFactor = 30;
    private bool backInTime = false;
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float waitTimeWhenDone = 2f;
    public FlashbackTime startingTime;
    private FlashbackTime targetTime;
    [HideInInspector] public FlashbackTime presentTime;
    [HideInInspector] public bool done = false;
    private Animator anim = null;

    [Header("Time")]
    public float minute1;
    public float minute2;
    public float hour1;
    public float hour2;

    [Header("Display")]
    [SerializeField] private Image minute1Display = null;
    [SerializeField] private Image minute2Display = null;
    [SerializeField] private Image dividerDisplay = null;
    [SerializeField] private Image hour1Display = null;
    [SerializeField] private Image hour2Display = null;

    [Header("Digital number images")]
    [SerializeField] private Sprite dn0 = null;
    [SerializeField] private Sprite dn2 = null;
    [SerializeField] private Sprite dn3 = null;
    [SerializeField] private Sprite dn4 = null;
    [SerializeField] private Sprite dn5 = null;
    [SerializeField] private Sprite dn6 = null;
    [SerializeField] private Sprite dn7 = null;
    [SerializeField] private Sprite dn8 = null;
    [SerializeField] private Sprite dn1 = null;
    [SerializeField] private Sprite dn9 = null;

    private float speed = 1;
    private bool startClock = false;
    private bool clockDone = false;
    private float hourTracker = 0;
    private float hourGoal = 0;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        presentTime = new FlashbackTime();
        presentTime.name = "_PresentTime";
        presentTime.minute1 = 0;
        presentTime.minute2 = 0;
        presentTime.hour1 = 3;
        presentTime.hour2 = 1;
        presentTime.flashback = false;

        Display(false);

        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateStartingTime();
    }

    public void Display(bool boolean)
    {
        if (boolean)
        {
            minute1Display.enabled = true;
            minute2Display.enabled = true;
            dividerDisplay.enabled = true;
            hour1Display.enabled = true;
            hour2Display.enabled = true;
        }

        if (!boolean)
        {
            minute1Display.enabled = false;
            minute2Display.enabled = false;
            dividerDisplay.enabled = false;
            hour1Display.enabled = false;
            hour2Display.enabled = false;
        }
    }

    private void UpdateStartingTime()
    {
        minute1 = startingTime.minute1;
        minute2 = startingTime.minute2;
        hour1 = startingTime.hour1;
        hour2 = startingTime.hour2;

        minute1Display.sprite = NumberToImage(minute1);
        minute2Display.sprite = NumberToImage(minute2);
        hour1Display.sprite = NumberToImage(hour1);
        hour2Display.sprite = NumberToImage(hour2);
    }

    public void SavePresentTime(float minutes, float hours)
    {
        presentTime.minute2 = Mathf.Abs(Mathf.Floor(minutes / 10));
        presentTime.minute1 = Mathf.Abs(minutes - (presentTime.minute2 * 10));
        presentTime.hour2 = Mathf.Abs(Mathf.Floor(hours / 10));
        presentTime.hour1 = Mathf.Abs(hours - (presentTime.hour2 * 10));
        Debug.Log("Converted digitalClock time:" + hours + ":" + minutes + " to presentTime: " + presentTime.hour2 + presentTime.hour1 + ":" + presentTime.minute2 + presentTime.minute1);
    }

    float CalculateTimeDifference(FlashbackTime targetTime)
    {
        float difference = 0;
        float startTime = (hour2 * 10) + hour1;
        float goalTime = (targetTime.hour2 * 10) + targetTime.hour1;

        if (targetTime.flashback)
        {
            if (startTime < goalTime) { difference = startTime + (24 - goalTime); }
            if (startTime > goalTime) { difference = (24 - startTime) + goalTime; }
            if (startTime == goalTime) { difference = 24; }
        }

        if (!targetTime.flashback)
        {
            if (startTime < goalTime) { difference = (24 - startTime) + goalTime; }
            if (startTime > goalTime) { difference = startTime + (24 - goalTime); }
            if (startTime == goalTime) { difference = 24; }
        }

        Debug.Log("Time difference: " + difference);
        return difference;
    }

    public IEnumerator TRAN_StartTransition(FlashbackTime newTargetTime)
    {
        Debug.Log("FlashbackClock - Starting courotine");

        targetTime = newTargetTime;
        speed = CalculateTimeDifference(targetTime) * speedFactor;
        Debug.Log("FlashbackClock - StartingTime: " + startingTime.name + " (" + startingTime.hour2 + startingTime.hour1 + ":" + startingTime.minute2
            + startingTime.minute1 + ") || TargetTime: " + targetTime.name + " (" + targetTime.hour2 + targetTime.hour1 + ":" + targetTime.minute2
            + targetTime.minute1 + ")");

        if (targetTime.flashback)
        {
            backInTime = true;
            flashback = true;
            startingTime = presentTime;
            SavePresentTime(DigitalClockScript.minutes, DigitalClockScript.hours);
            UpdateStartingTime();
            hourGoal = CalculateTimeDifference(targetTime);
            Debug.Log("FlashbackClock - hourGoal = " + hourGoal);
        }
        else { backInTime = false; flashback = false; }

        yield return new WaitForSeconds(startDelay);
        anim.SetTrigger("start");
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[0].length);
        startClock = true;

        yield return new WaitUntil(() => clockDone);
        Debug.Log("FlashbackClock - Continuing courotine");

        yield return new WaitForSeconds(waitTimeWhenDone);
        anim.SetTrigger("done");
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[1].length * 2f);
        done = true;

        yield return null;
    }

    private void RunClock()
    {
        if (!backInTime && hourTracker >= hourGoal)
        {
            DoneClock();
            minute1 = targetTime.minute1;
            minute2 = targetTime.minute2;
            minute1Display.sprite = NumberToImage(minute1);
            minute2Display.sprite = NumberToImage(minute2);
            return;
        }
        if (!backInTime && !done)
        {
            minute1 += Time.deltaTime * speed;
            minute1Display.sprite = NumberToImage(minute1);
        }

        if (backInTime && hourTracker >= hourGoal)
        {
            DoneClock();
            minute1 = targetTime.minute1;
            minute2 = targetTime.minute2;
            minute1Display.sprite = NumberToImage(minute1);
            minute2Display.sprite = NumberToImage(minute2);
            return;
        }
        if (backInTime && !done)
        {
            minute1 -= Time.deltaTime * speed;
            minute1Display.sprite = NumberToImage(minute1);
        }
    }

    private void RunClock2()
    {
        // Problem: Clock doesnt change if targetTime is same as startingTime

        if (!backInTime && minute1 == targetTime.minute1 && minute2 == targetTime.minute2 && hour1 == targetTime.hour1 && hour2 == targetTime.hour2)
        {
            DoneClock();
        }
        else if (!backInTime)
        {
            minute1 += Time.deltaTime * speed;
            minute1Display.sprite = NumberToImage(minute1);
        }

        if (backInTime && minute1 <= (targetTime.minute1 + 1) && minute2 == targetTime.minute2 && hour1 == targetTime.hour1 && hour2 == targetTime.hour2)
        {
            DoneClock();
        }
        else if (backInTime)
        {
            minute1 -= Time.deltaTime * speed;
            minute1Display.sprite = NumberToImage(minute1);
        }
    }

    void DoneClock()
    {
        Debug.Log("FlashbackClock - Done");
        clockDone = true;
        startClock = false;
        //currentFlashbackTime = null;
        startingTime = targetTime;
        hourTracker = 0;
        return;
    }

    private Sprite NumberToImage(float number)
    {
        switch (Mathf.FloorToInt(number))
        {
            case 0:
                return dn0;
            case 1:
                return dn1;
            case 2:
                return dn2;
            case 3:
                return dn3;
            case 4:
                return dn4;
            case 5:
                return dn5;
            case 6:
                return dn6;
            case 7:
                return dn7;
            case 8:
                return dn8;
            case 9:
                return dn9;
        }
        return dn0;
    }

    private void Update()
    {
        if (startClock)
        {
            RunClock();
        }

        // If going back in time
        if (minute1 < 0)
        {
            minute2--;
            minute2Display.sprite = NumberToImage(minute2);
            minute1 = 9;
            minute1Display.sprite = NumberToImage(minute1);
        }

        if (minute2 < 0)
        {
            hourTracker++;
            Debug.Log("HourTracker: " + hourTracker);
            hour1--;
            hour1Display.sprite = NumberToImage(hour1);
            minute2 = 5;
            minute2Display.sprite = NumberToImage(minute2);
        }

        if (hour1 < 0)
        {
            hour2--;
            hour2Display.sprite = NumberToImage(hour2);
            hour1 = 9;
            hour1Display.sprite = NumberToImage(hour1);
        }

        if (hour2 < 0)
        {
            hour2 = 2;
            hour2Display.sprite = NumberToImage(hour2);
            hour1 = 3;
            hour1Display.sprite = NumberToImage(hour1);
            minute2 = 5;
            minute2Display.sprite = NumberToImage(minute2);
            minute1 = 9;
            minute1Display.sprite = NumberToImage(minute1);
        }


        // If going forward in time
        if (minute2 == 6 && minute1 > 0)
        {
            hour1++;
            minute1 = 0;
            minute1Display.sprite = NumberToImage(minute1);
            minute2 = 0;
            minute2Display.sprite = NumberToImage(minute2);
        }

        if (minute1 > 9)
        {
            minute2++;
            minute2Display.sprite = NumberToImage(minute2);
            minute1 = 0;
            minute1Display.sprite = NumberToImage(minute1);
        }

        if (minute2 > 5)
        {
            hourTracker++;
            Debug.Log("HourTracker: " + hourTracker);
            hour1++;
            hour1Display.sprite = NumberToImage(hour1);
            minute2 = 0;
            minute2Display.sprite = NumberToImage(minute2);
        }

        if (hour2 == 2 && hour1 == 4)
        {
            hour1 = 0;
            hour1Display.sprite = NumberToImage(hour1);
            hour2 = 0;
            hour2Display.sprite = NumberToImage(hour2);
        }

        if (hour1 > 9)
        {
            hour2++;
            hour2Display.sprite = NumberToImage(hour2);
            hour1 = 0;
            hour1Display.sprite = NumberToImage(hour1);
        }
    }
}
