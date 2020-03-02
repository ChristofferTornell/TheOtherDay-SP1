using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Phone phone;
    public Button _HomeButton;
    public Button _BackButton;
    public GameObject[] Menus;

    private void Start()
    {
        _HomeButton.onClick.AddListener(HomeButton);
        _BackButton.onClick.AddListener(BackbuttonFunc);
    }

    private void HomeButton()
    {
        for (int i = Menus.Length; i > 0; i--)
        {
            Menus[i - 1].SetActive(false);
        }
        phone.Zoom();
    }

    private void BackbuttonFunc()
    {
        for (int i = Menus.Length - 1; i >= 0; i--)
        {
            if (Menus[i].activeSelf)
            {
                Debug.Log(i);
                Menus[i].SetActive(false);
                if(i == 0)
                {
                    phone.Zoom();
                }
            }
            return;
        }
    }
}
