using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blink : MonoBehaviour
{
    public float BlinkInterval = 1;
    private float BlinkTime = 0;
    public GameObject[] Target;
    private bool NewNotification = true;
    private TextMeshProUGUI text;
    public int Notifications = 1;

    private void Start()
    {
        text = GetText();
        if(text != null)
        {
            text.text = GetString(Notifications);
        }
    }

    private void Update()
    {
        if (NewNotification == true)
        {
            BlinkTime += Time.deltaTime;
            if(BlinkTime > BlinkInterval)
            {
                for (int i = 0; i < Target.Length; i++)
                {
                    Target[i].SetActive(!Target[i].activeSelf);
                }
                BlinkTime = 0;
            }
        }
    }

    private TextMeshProUGUI GetText()
    {
        TextMeshProUGUI text;
        for (int i = 0; i < Target.Length; i++)
        {
            text = Target[i].GetComponent<TextMeshProUGUI>();
            if(text != null)
            {
                return text;
            }
        }
        return null;
    }

    private string GetString(int x)
    {
        switch (x)
        {
            case 1:
                return "1";
            break;

            case 2:
                return "2";
            break;

            case 3:
                return "3";
            break;

            case 4:
                return "4";
            break;

            case 5:
                return "5";
            break;

            case 6:
                return "6";
            break;
        }
        return "1";
    }
}
