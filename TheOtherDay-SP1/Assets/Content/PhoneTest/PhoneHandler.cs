using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneHandler : MonoBehaviour
{
    public Button CallButton;
    public GameObject CallPage;

    private void Start()
    {
        CallButton.onClick.AddListener(EnableCall);
    }

    void EnableCall()
    {
        CallPage.SetActive(true);
    }

    void EnableMessages()
    {

    }

    void EnableLog()
    {

    }

    void EnableAlbum()
    {

    }
}
