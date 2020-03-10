using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackEvents : SceneEvents
{
    public void ShowObject()
    {
        Debug.Log("showing object");
        objectAppear.SetActive(true);
        Debug.Log(objectAppear.activeSelf);
    }
}
