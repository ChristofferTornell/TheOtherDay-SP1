using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    private bool Pulled = false;
    private bool Pulling = false;
    private float PullUpTime = 0;
    private float PullUpLimit = 0.169f;
    private float PressingDelta = 0.6f;
    private float PressingTime = 0;
    public KeyCode PullUpKey = KeyCode.P;
    public float PullSpeed = 40;

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
        MessageButton.onClick.AddListener(delegate { EnableMessage(true); });
        LogButton.onClick.AddListener(delegate { EnableLog(true); });
        AlbumButton.onClick.AddListener(delegate { EnableAlbum(true); });
        PullUpButton.onClick.AddListener(PullUp);
        PullDownButton.onClick.AddListener(PullDown);
    }

    void EnableCall(bool state)
    {
        CallPage.SetActive(state);
    }

    void EnableMessage(bool state)
    {
        MessagePage.SetActive(state);
    }

    void EnableLog(bool state)
    {
        LogPage.SetActive(state);
    }

    void EnableAlbum(bool state)
    {
        AlbumPage.SetActive(state);
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
        EnableAlbum(false);
        EnableLog(false);
        EnableMessage(false);
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
            if (Input.GetKeyDown(PullUpKey))
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
                transform.position += new Vector3(0, PullSpeed, 0);
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
                transform.position += new Vector3(0, -1 * PullSpeed, 0);
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