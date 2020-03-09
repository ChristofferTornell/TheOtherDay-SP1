using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    [HideInInspector]public bool Pulled = false;
    private float PressingDelta = 0.6f;
    private float PressingTime = 0;
    public float PullSpeed = 40;

    public GameObject SettingsPage;
    public Button SettingsButton;
    public GameObject ExitBox;

    public Button MessageButton;
    public GameObject MessagePage;

    public Button LogButton;
    public GameObject LogPage;

    public Button AlbumButton;
    public GameObject AlbumPage;

    public Button PullUpButton;
    //public Button PullDownButton;

    public Animator ani;

    [HideInInspector]public int Page = -1;

    [HideInInspector]public bool Zoomed = false;
    
    private void Start()
    {
        SettingsButton.onClick.AddListener(delegate { EnableSettings(true); });
        MessageButton.onClick.AddListener(delegate { EnableMessage(true); });
        LogButton.onClick.AddListener(delegate { EnableLog(true); });
        AlbumButton.onClick.AddListener(delegate { EnableAlbum(true); });
        PullUpButton.onClick.AddListener(PullUp);
        //PullDownButton.onClick.AddListener(PullDown);
    }

    void EnableSettings(bool state)
    {
        Page = 2;
        SettingsPage.SetActive(state);
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
        PressingTime = 0;
        ani.Play("Up");
        Pulled = true;
        //PullDownButton.gameObject.SetActive(true);
        PullUpButton.gameObject.SetActive(false);
    }

    public void Zoom(bool state)
    {
        if (state)
        {
            ani.Play("Zoom In");
            Zoomed = true;
        }
        else
        {
            ani.Play("Zoom out");
            Zoomed = false;
        }
    }

    public void ExitGame()
    {
        Instantiate(ExitBox, new Vector3(455, 200, 0), Quaternion.identity).transform.parent = gameObject.transform;
    }

    private void Update()
    {
        PressingTime += Time.deltaTime;
        if (!Pulled)
        {
            PullUpButton.gameObject.SetActive(true);
        }
        else
        {
            PullUpButton.gameObject.SetActive(false);
        }
    }
}