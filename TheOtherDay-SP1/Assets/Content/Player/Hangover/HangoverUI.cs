using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangoverUI : MonoBehaviour
{
    public Text hangoverText;
    public HangoverManager hangoverManager = null;

    void UpdateHangoverUI()
    {
        hangoverText.text = "HangoverLevel: " + hangoverManager.CurrentHangover.ToString();
    }

    public void OnHangoverManagerChange(HangoverManager hangoverManager, int hangoverChange)
    {
        UpdateHangoverUI();
    }

    public void OnEnable()
    {
        UpdateHangoverUI();
        hangoverManager.onChange += OnHangoverManagerChange;
    }
    public void OnDisable()
    {
        hangoverManager.onChange -= OnHangoverManagerChange;
    }
}
