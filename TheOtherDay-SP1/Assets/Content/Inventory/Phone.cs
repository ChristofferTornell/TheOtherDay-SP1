using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public Button CallButton;
    public GameObject CallPage;

    public Button MessageButton;
    public GameObject MessagePage;

    public Button LogButton;
    public GameObject LogPage;

    public Button AlbumButton;
    public GameObject AlbumPage;

    private void Start()
    {
        CallButton.onClick.AddListener(EnableCall);
        MessageButton.onClick.AddListener(EnableMessage);
        LogButton.onClick.AddListener(EnableLog);
        AlbumButton.onClick.AddListener(EnableAlbum);
    }

    void EnableCall()
    {
        CallPage.SetActive(true);
    }

    void EnableMessage()
    {
        MessagePage.SetActive(true);
    }

    void EnableLog()
    {
        LogPage.SetActive(true);
    }

    void EnableAlbum()
    {
        AlbumPage.SetActive(true);
    }
}
