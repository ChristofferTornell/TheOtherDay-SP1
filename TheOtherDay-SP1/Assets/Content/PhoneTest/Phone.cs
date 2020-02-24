using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    private bool Pulled = false;
    private bool Pulling = false;
    private float PullUpTime = 0;
    private float PullUpLimit = 0.17f;
    private float PressingDelta = 0.6f;
    private float PressingTime = 0;

   // public Button CallButton;
    public GameObject CallPage;

    public Button MessageButton;
    public GameObject MessagePage;

    public Button LogButton;
    public GameObject LogPage;

    public Button AlbumButton;
    public GameObject AlbumPage;

    public Button PullUpButton;
    public Button PullDownButton;
    
    private void Start()
    {
        //CallButton.onClick.AddListener(EnableCall);
        MessageButton.onClick.AddListener(EnableMessage);
        LogButton.onClick.AddListener(EnableLog);
        AlbumButton.onClick.AddListener(EnableAlbum);
        PullUpButton.onClick.AddListener(PullUp);
        PullDownButton.onClick.AddListener(PullDown);
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

    private void PullUp()
    {
        PullUpTime = 0;
        Pulling = true;
        PullUpButton.gameObject.SetActive(false);
        PullDownButton.gameObject.SetActive(true);
        Debug.Log("Pulled up");
    }

    void PullDown()
    {
        PullUpTime = 0;
        Pulling = true;
        PullUpButton.gameObject.SetActive(true);
        PullDownButton.gameObject.SetActive(false);
        Debug.Log("Pulled down");
    }

    private void Update()
    {
        PressingTime += Time.deltaTime;
        if(PressingTime > PressingDelta && Pulling == false)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if(Pulled == false)
                {
                    PullUp();
                }
                else
                {
                    PullDown();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (Pulling == true && Pulled == false)
        {
            PullUpTime += Time.fixedDeltaTime;
            if (PullUpTime < PullUpLimit)
            {
                transform.position += new Vector3(0, 35, 0);
            }
            else
            {
                Pulling = false;
                Pulled = true;
                PressingTime = 0;
            }
        }
        if (Pulling == true && Pulled == true)
        {
            PullUpTime += Time.fixedDeltaTime;
            if (PullUpTime < PullUpLimit)
            {
                transform.position += new Vector3(0, -35, 0);
            }
            else
            {
                Pulling = false;
                Pulled = false;
                PressingTime = 0;
            }
        }
    }
}