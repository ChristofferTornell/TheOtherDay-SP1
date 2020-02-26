using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float BlinkInterval = 1;
    private float BlinkTime = 0;
    public GameObject[] Target;
    private bool NewNotification = true;
    public int Notifications = 1;

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
        else
        {
            for (int i = 0; i < Target.Length; i++)
            {
                Target[i].SetActive(false);
            }
        }
    }

    public void ChangeNotificationState(bool state)
    {
        NewNotification = state;
    }
}
