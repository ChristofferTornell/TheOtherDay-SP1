using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool pause = false;
    public static Scene currentScene;

    private void Start()
    {
        currentScene = gameObject.scene;
        pause = false;
        Time.timeScale = 1;
    }

    public static void Pause(bool boolean)
    {
        if (boolean) { pause = true; }
        else { pause = false; }
    }
}
