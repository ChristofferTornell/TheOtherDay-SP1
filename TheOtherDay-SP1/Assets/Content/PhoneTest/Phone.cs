using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    private bool PullUp = false;
    private float PullUpTime = 0;
    private float PullUpLimit = 0.2f;
    private Vector3 initPos;

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

    private void OnEnable()
    {
        PullUp = true;
        PullUpTime = 0;
    }

    private void FixedUpdate()
    {
        if(PullUp == true)
        {
            PullUpTime += Time.deltaTime;
            if(PullUpTime < PullUpLimit)
            {
                transform.position += new Vector3(0, 45, 0);
            }
        }
    }

    private void Awake()
    {
        initPos = transform.position;
    }

    private void OnDisable()
    {
        transform.position = initPos;
    }
}