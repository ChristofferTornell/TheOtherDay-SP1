﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool pause = false;

    private void Start()
    {
        pause = false;
        Time.timeScale = 1;
    }

    public static void Pause(bool boolean)
    {
        if (boolean) { pause = true; }
        else { pause = false; }
    }
}
