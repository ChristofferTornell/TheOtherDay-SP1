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

    [HideInInspector]public int Page;

    private bool Zoomed = false;
    private bool Zooming = false;
    private float ZoomTimeDelta = 0;
    private Vector3 ZoomedScale = new Vector3(2.275618f, 4.569676f, 0);
    private Vector3 NonZoomedScale = new Vector3(1.576948f, 3.166675f, 0);
    private float speed = 0.1f;
    
    private void Start()
    {
        //CallButton.onClick.AddListener(EnableCall);
        MessageButton.onClick.AddListener(delegate { EnableMessage(true); });
        LogButton.onClick.AddListener(delegate { EnableLog(true); });
        AlbumButton.onClick.AddListener(delegate { EnableAlbum(true); });
        PullUpButton.onClick.AddListener(PullUp);
        PullDownButton.onClick.AddListener(delegate { PullDown(); PullDownButtonFunc(); });
    }

    void EnableCall(bool state)
    {
        CallPage.SetActive(state);
    }

    void EnableMessage(bool state)
    {
        Page = 0;
        MessagePage.SetActive(state);
    }

    void EnableLog(bool state)
    {
       Page = 1;
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
    }

    public void Zoom()
    {
        Zooming = true;
    }

    public void PullDownButtonFunc()
    {
        if (Zoomed)
        {
            Zoom();
        }
    }

    private void Update()
    {
        PressingTime += Time.deltaTime;
        ZoomTimeDelta += Time.deltaTime;
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
                    PullDownButtonFunc();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        /*PullUp*/{
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

        /*ZoomIn*/{
            if(Zooming && !Zoomed)
            {
                PullDownButton.gameObject.SetActive(false);
                Vector3 desiredScale = ZoomedScale;
                Vector3 smoothedScale = Vector3.Lerp(transform.localScale, desiredScale, 0.25f);
                transform.localScale = smoothedScale;
                if(transform.localScale == desiredScale)
                {
                    Zooming = false;
                    Zoomed = !Zoomed;
                    PullDownButton.gameObject.SetActive(true);
                }
            }
            if (Zooming && Zoomed)
            {
                PullDownButton.gameObject.SetActive(false);
                Vector3 desiredScale = NonZoomedScale;
                Vector3 smoothedScale = Vector3.Lerp(transform.localScale, desiredScale, 0.25f);
                transform.localScale = smoothedScale;
                if (transform.localScale == desiredScale)
                {
                    Zooming = false;
                    Zoomed = !Zoomed;
                    PullDownButton.gameObject.SetActive(true);
                }
            }
            }
    }
}