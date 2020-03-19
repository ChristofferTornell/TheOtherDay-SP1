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
    [Space]
    [Tooltip("Whether this time is during a flashback or not, which determines if the clock goes backwards or not")]
    public bool flashback = false;
}

public class FlashbackTransitionClock : MonoBehaviour
{
    public static FlashbackTransitionClock instance;
    public float speed = 50f;
    public float duration = 3f;
    [SerializeField] private bool backInTime = false;
    [SerializeField] private float delay = 2f;
    public FlashbackTime startingTime;
    public FlashbackTime targetTime;

    [Header("Time")]
    [SerializeField] private float minute1;
    [SerializeField] private float minute2;
    [SerializeField] private float hour1;
    [SerializeField] private float hour2;

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

    private bool startClock = false;
    private bool clockDone = false;
    private float timeDifference = 0;

    float timetracker = 0;

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
        minute1 = startingTime.minute1;
        minute2 = startingTime.minute2;
        hour1 = startingTime.hour1;
        hour2 = startingTime.hour2;

        minute1Display.sprite = NumberToImage(minute1);
        minute2Display.sprite = NumberToImage(minute2);
        hour1Display.sprite = NumberToImage(hour1);
        hour2Display.sprite = NumberToImage(hour2);
    }

    void CalculateTimeDifference()
    {
        // Difference in virtual hours
        // 1 IRL minute = 1 virtual hour on (speed = 1)
        float difference = (Mathf.Abs(hour2 - targetTime.hour2) * 10) + Mathf.Abs(hour1 - targetTime.hour1);
        Debug.Log("Time difference: " + difference);
        timeDifference = difference;
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

    public IEnumerator TRAN_FlashbackTimeChange(FlashbackTime targetTime)
    {
        Debug.Log("FlashbackClock - Starting courotine");
        if (targetTime.flashback)
        {
            backInTime = true;
        }
        else { backInTime = false; }

        yield return new WaitForSeconds(delay);

        startClock = true;

        yield return new WaitUntil(() => clockDone);
        Debug.Log("FlashbackClock - Continuing courotine");

        // The transition has a set duration. And the speed of which the clock goes should account for this.

        yield return null;
    }

    private void StartClock()
    {
        //if (!clockDone) Debug.Log("FlashbackClock - Ticking");

        if (!backInTime && minute1 >= targetTime.minute1 && minute2 >= targetTime.minute2 && hour1 >= targetTime.hour1 && hour2 >= targetTime.hour2)
        {
            Debug.Log("FlashbackClock - Ticking Done");
            clockDone = true;
            startClock = false;
            return;
        }
        else if (!backInTime)
        {
            minute1 += Time.deltaTime * speed;
            minute1Display.sprite = NumberToImage(minute1);
        }
        if (minute1 <= targetTime.minute1) { Debug.Log("test"); }

        if (backInTime && minute1 <= (targetTime.minute1 + 1) && minute2 <= targetTime.minute2 && hour1 == targetTime.hour1 && hour2 == targetTime.hour2)
        {
            Debug.Log("FlashbackClock - Ticking Done");
            clockDone = true;
            startClock = false;
            return;
        }
        else if (backInTime)
        {
            minute1 -= Time.deltaTime * speed;
            minute1Display.sprite = NumberToImage(minute1);
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
        return dn0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(TRAN_FlashbackTimeChange(targetTime));
        }

        if (startClock)
        {
            StartClock();
        }

        timetracker += Time.deltaTime;

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
            Debug.Log(timetracker);
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
