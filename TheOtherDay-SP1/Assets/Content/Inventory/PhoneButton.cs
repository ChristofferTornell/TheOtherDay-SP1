using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneButton : MonoBehaviour
{
    public Button button;
    public GameObject phone;
    private new bool enabled = false;

    private void Start()
    {
        button.onClick.AddListener(click);
    }

    void click()
    {
        if(enabled == false)
        {
            phone.SetActive(true);
            enabled = true;
        }
        else
        {
            phone.SetActive(false);
            enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            click();
        }
    }
}
