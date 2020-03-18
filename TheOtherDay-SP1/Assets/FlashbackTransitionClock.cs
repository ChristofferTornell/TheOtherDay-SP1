using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class FlashbackTime : ScriptableObject
{
    [Header("The digital time (h2 h1 : m2 m1)")]
    public float minute1;
    public float minute2;
    public float hour1;
    public float hour2;
}

public class FlashbackTransitionClock : MonoBehaviour
{
    public float speed = 50f;
    public bool backInTime = false;
    public float delay = 2f;
    public FlashbackTime startingTime;
    public FlashbackTime targetTime;

    [Header("Time")]
    public float minute1;
    public float minute2;
    public float hour1;
    public float hour2;

    [Header("Display")]
    public Image minute1Display = null;
    public Image minute2Display = null;
    public Image dividerDisplay = null;
    public Image hour1Display = null;
    public Image hour2Display = null;

    [Header("Digital number images")]
    public Sprite dn0 = null;
    public Sprite dn1 = null;
    public Sprite dn2 = null;
    public Sprite dn3 = null;
    public Sprite dn4 = null;
    public Sprite dn5 = null;
    public Sprite dn6 = null;
    public Sprite dn7 = null;
    public Sprite dn8 = null;
    public Sprite dn9 = null;

    public static FlashbackTransitionClock instance;
    private bool done = false;
    private bool startClock = false;

    void Awake()
    {
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
        minute1Display.sprite = NumberToImage(minute1);
        minute2Display.sprite = NumberToImage(minute2);
        hour1Display.sprite = NumberToImage(hour1);
        hour2Display.sprite = NumberToImage(hour2);

        //StartCoroutine(FlashbackTimeChange(false, 3));
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }

    public IEnumerator FlashbackTimeChange(FlashbackTime targetTime)
    {
        Debug.Log("FlashbackClock - Starting courotine");
        if (startingTime.hour1 > targetTime.hour1 && startingTime.hour2 > targetTime.hour2)
        {
            backInTime = true;
        }
        else { backInTime = false; }

        yield return new WaitForSeconds(delay);

        startClock = true;

        yield return new WaitUntil(() => done);
        Debug.Log("FlashbackClock - Continuing courotine");

        yield return null;
    }

    private void StartClock()
    {
        Debug.Log("FlashbackClock - Ticking");
        minute1 += Time.deltaTime * speed;
        minute1Display.sprite = NumberToImage(minute1);
        if (!backInTime && minute1 != targetTime.minute1 && minute2 != targetTime.minute2 && hour1 != targetTime.hour1 && hour2 != targetTime.hour2)
        {
            minute1 += Time.deltaTime * speed;
            minute1Display.sprite = NumberToImage(minute1);
        }
        else if (!backInTime && minute1 >= targetTime.minute1 && minute2 >= targetTime.minute2 && hour1 >= targetTime.hour1 && hour2 >= targetTime.hour2)
        {
            done = true;
            startClock = false;
            return;
        }

        if (backInTime && minute1 != targetTime.minute1 && minute2 != targetTime.minute2 && hour1 != targetTime.hour1 && hour2 != targetTime.hour2)
        {
            minute1 -= Time.deltaTime * speed;
            minute1Display.sprite = NumberToImage(minute1);
        }
        else if(backInTime && minute1 <= targetTime.minute1 && minute2 <= targetTime.minute2 && hour1 <= targetTime.hour1 && hour2 <= targetTime.hour2)
        {
            done = true;
            startClock = false;
            return;
        }
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
        //Debug.LogError("That number doesn't have a corresponding image");
        return dn0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(FlashbackTimeChange(targetTime));
        }

        if (startClock)
        {
            StartClock();
        }

        //minute1 -= Time.deltaTime * speed;
        //minute1Display.sprite = NumberToImage(minute1);

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
            minute1 = 0;
            minute1Display.sprite = NumberToImage(minute1);
            minute2 = 0;
            minute2Display.sprite = NumberToImage(minute2);
            hour1++;
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
