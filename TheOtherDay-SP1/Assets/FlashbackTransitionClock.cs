using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlashbackTransitionClock : MonoBehaviour
{
    public bool backInTime = false;

    [Header("Time")]
    [Space]
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
    public Image dn0 = null;
    public Image dn1 = null;
    public Image dn2 = null;
    public Image dn3 = null;
    public Image dn4 = null;
    public Image dn5 = null;
    public Image dn6 = null;
    public Image dn7 = null;
    public Image dn8 = null;
    public Image dn9 = null;

    public IEnumerator FlashbackTimeChange()
    {

        // Pause scene change
        // A time parameter the clock should rapidly change to
        // When the last few numbers are close, slow down the ticking for extra juice
        // Player sound effects
        // When done, resume scene change

        // Accelerate ticking speed on start
        // Deccelerate when closing in on target

        yield return null;
    }

    private Image NumberToImage(float number)
    {
        switch (number)
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
        Debug.LogError("That number doesn't have a corresponding image");
        return null;
    }

    private void Update()
    {
        // 08:00
        // 07:59
        // 24:00
        // 23:59
        // 20:00
        // 19:59

        if (backInTime)
        {
            if (minute1 < 0)
            {
                minute2--;
                minute2Display = NumberToImage(minute2);
                minute1 = 9;
                minute1Display = NumberToImage(minute1);
            }

            if (minute2 < 0)
            {
                hour1--;
                hour1Display = NumberToImage(hour1);
                minute2 = 5;
                minute2Display = NumberToImage(minute2);
            }

            if (hour1 < 0)
            {
                hour2--;
                hour2Display = NumberToImage(hour2);
                hour1 = 9;
                hour1Display = NumberToImage(hour1);

            }

            if (hour2 < 0)
            {
                hour2 = 2;
                hour2Display = NumberToImage(hour2);
                hour1 = 3;
                hour1Display = NumberToImage(hour1);
                minute2 = 5;
                minute2Display = NumberToImage(minute2);
                minute1 = 9;
                minute1Display = NumberToImage(minute1);
            }
        }

        // If going forward in time
        else
        {
            if (minute2 == 6 && minute1 > 0)
            {
                minute1 = 0;
                minute1Display = NumberToImage(minute1);
                minute2 = 0;
                minute2Display = NumberToImage(minute2);
                hour1++;
            }

            if (minute1 > 9)
            {
                minute2++;
                minute2Display = NumberToImage(minute2);
                minute1 = 0;
                minute1Display = NumberToImage(minute1);
            }

            if (minute2 > 9)
            {
                hour1++;
                hour1Display = NumberToImage(hour1);
                minute2 = 0;
                minute2Display = NumberToImage(minute2);
            }

            if (hour2 == 2 && hour1 > 4)
            {
                hour1 = 0;
                hour1Display = NumberToImage(hour1);
                hour2 = 0;
                hour2Display = NumberToImage(hour2);
            }

            if (hour1 > 9)
            {
                hour2++;
                hour2Display = NumberToImage(hour2);
                hour1 = 0;
                hour1Display = NumberToImage(hour1);
            }
        }
    }
}
