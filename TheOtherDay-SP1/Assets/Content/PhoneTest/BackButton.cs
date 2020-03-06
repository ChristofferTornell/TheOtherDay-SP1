﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BackButton : MonoBehaviour
{
    public Phone phone;
    public Button _HomeButton;
    public Button _BackButton;
    public List<GameObject> MessageMenus;
    public GameObject LogMenu;
    private GameObject[] MessageBubbles;
    public GameObject SettingsMenu;

    public VideoPlayer vp;
    private GameObject parent;

    private void Start()
    {
        parent = GameObject.Find("Video player paretn");
        _HomeButton.onClick.AddListener(HomeButton);
        _BackButton.onClick.AddListener(BackbuttonFunc);
        vp.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = 0;
        Debug.Log("end");
        parent.SetActive(false);
    }

    private void HomeButton()
    {
        if (phone.Page == 0)
        {
            if(MessageBubbles != null)
            {
                ResetMessages();
            }
            for (int i = MessageMenus.Count - 1; i >= 0; i--)
            {
                MessageMenus[i].SetActive(false);
            }
            MessageMenus.RemoveRange(1, MessageMenus.Count - 1);
            if (phone.Zoomed)
            {
                phone.Zoom();
            }
        }
        else if(phone.Page == 1)
        {
            LogMenu.SetActive(false);
        }
        else if(phone.Page == 2)
        {
            SettingsMenu.SetActive(false);
        }
        phone.Page = -1;
    }

    public void AddToList(GameObject obj)
    {
        MessageMenus.Add(obj);
        if(obj.name == "In Message")
        {
            MessageBubbles = obj.GetComponent<InMessage>().TextBubbles;
            int stage = obj.GetComponent<InMessage>().stage;
            if(stage == 0)
            {
                Button[] f = obj.GetComponent<InMessage>().ForwardArrow;
                Button[] b = obj.GetComponent<InMessage>().BackArrow;
                for (int i = 0; i < f.Length; i++)
                {
                    f[i].gameObject.SetActive(false);
                    b[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void ResetMessages()
    {
        for (int i = 0; i < MessageBubbles.Length; i++)
        {
            if(i == 0)
            {
                MessageBubbles[i].SetActive(true);
            }
            else
            {
                MessageBubbles[i].SetActive(false);
            }
        }
    }
    
    private void BackbuttonFunc()
    {
        if(phone.Page == 0)
        {
            if(MessageBubbles != null)
            {
                ResetMessages();
            }
            for (int i = MessageMenus.Count - 1; i >= 0; i--)
            {
                if (MessageMenus[i].activeSelf)
                {
                    MessageMenus[i].SetActive(false);
                    if(i == 0)
                    {
                        phone.Zoom();
                        phone.Page = -1;
                    }
                    else
                    {
                        MessageMenus.Remove(MessageMenus[i]);
                    }
                    return;
                }
            }
        }
        else if(phone.Page == 1)
        {
            LogMenu.SetActive(false);
            phone.Page = -1;
        }
        else if(phone.Page == 2)
        {
            SettingsMenu.SetActive(false);
            phone.Page = -1;
        }
    }
}
