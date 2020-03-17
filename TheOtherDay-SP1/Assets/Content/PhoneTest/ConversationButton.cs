using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationButton : MonoBehaviour
{
    public Button myButton;

    private void Start()
    {
        myButton.onClick.AddListener(GoToMessages);
    }

    public void GoToMessages()
    {
        if (HotelEvents.instance != null)
        {
            HotelEvents.instance.CheckEvent(12);
        }
    }
}
