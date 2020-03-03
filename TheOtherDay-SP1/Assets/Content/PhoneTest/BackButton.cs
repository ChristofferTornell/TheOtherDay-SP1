using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Phone phone;
    public Button _HomeButton;
    public Button _BackButton;
    public GameObject[] MessageMenus;
    public GameObject LogMenu;

    private void Start()
    {
        _HomeButton.onClick.AddListener(HomeButton);
        _BackButton.onClick.AddListener(BackbuttonFunc);
    }

    private void HomeButton()
    {
        if (phone.Page == 0)
        {
            int count = 0;
            for (int i = 0; i < MessageMenus.Length; i++)
            {
                if (!MessageMenus[i].activeSelf)
                {
                    count++;
                }
            }
            if(count != MessageMenus.Length)
            {
                for (int i = MessageMenus.Length; i > 0; i--)
                {
                    MessageMenus[i - 1].SetActive(false);
                }
                phone.Zoom();
            }
        }
        else if(phone.Page == 1)
        {
            LogMenu.SetActive(false);
        }
    }

    private void BackbuttonFunc()
    {
        if(phone.Page == 0)
        {
            for (int i = MessageMenus.Length - 1; i >= 0; i--)
            {
                if (MessageMenus[i].activeSelf)
                {
                    MessageMenus[i].SetActive(false);
                    if(i == 0)
                    {
                        phone.Zoom();
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
