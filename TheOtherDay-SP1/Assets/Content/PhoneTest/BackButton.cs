using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Phone phone;
    public Button _HomeButton;
    public Button _BackButton;
    public List<GameObject> MessageMenus;
    public GameObject LogMenu;
    private GameObject[] MessagePages;

    private void Start()
    {
        _HomeButton.onClick.AddListener(HomeButton);
        _BackButton.onClick.AddListener(BackbuttonFunc);
    }

    private void HomeButton()
    {
        if (phone.Page == 0)
        {
            ResetMessages();
            for (int i = MessageMenus.Count - 1; i >= 0; i--)
            {
                MessageMenus[i].SetActive(false);
            }
            MessageMenus.RemoveRange(1, MessageMenus.Count - 1);
            if (phone.Zoomed)
            {
                phone.Zoom();
            }
            phone.Page = -1;
        }
        else if(phone.Page == 1)
        {
            LogMenu.SetActive(false);
            phone.Page = -1;
        }
    }

    public void AddToList(GameObject obj)
    {
        MessageMenus.Add(obj);
        if(obj.name == "In Message")
        {
            MessagePages = obj.GetComponent<InMessage>().TextBubbles;
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
        for (int i = 0; i < MessagePages.Length; i++)
        {
            if(i == 0)
            {
                MessagePages[i].SetActive(true);
            }
            else
            {
                MessagePages[i].SetActive(false);
            }
        }
    }
    
    private void BackbuttonFunc()
    {
        if(phone.Page == 0)
        {
            ResetMessages();
            for (int i = MessageMenus.Count - 1; i >= 0; i--)
            {
                if (MessageMenus[i].activeSelf)
                {
                    MessageMenus[i].SetActive(false);
                    if(i == 0)
                    {
                        phone.Zoom();
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
        }
    }
}
