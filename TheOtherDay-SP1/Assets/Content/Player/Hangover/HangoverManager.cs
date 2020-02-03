using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "HangoverData", menuName = "ScriptableObjects/HangoverManager", order = 1)]

public class HangoverManager : ScriptableObject
{
    public UnityAction<HangoverManager, int> onChange = delegate { };
    public int startHangover = 100;
    private int _currentHangover = 0;
    public int CurrentHangover
    {
        get
        {
            return _currentHangover;
        }

        set
        {
            if (_currentHangover != value)
            {
                int hangoverChange = value - _currentHangover;
                _currentHangover = value;
                onChange(this, hangoverChange);
            }
        }
    }
    public void OnEnable()
    {
        _currentHangover = startHangover;
    }

}
