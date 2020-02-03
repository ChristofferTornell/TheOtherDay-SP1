using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    [Header("Hangover")]
    public HangoverManager hangoverManager;
    public int increaseHangoverAmount = 1;
    public int decreaseHangoverAmount = 1;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) //TESTING PURPOSE
        {
            hangoverManager.CurrentHangover += increaseHangoverAmount;
        }
        if (Input.GetKeyDown(KeyCode.J)) //TESTING PURPOSE
        {
            hangoverManager.CurrentHangover -= decreaseHangoverAmount;
        }
    }
}
