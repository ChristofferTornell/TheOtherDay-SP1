using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool pause = false;
    public static string currentScene;

    [SerializeField] private Transform startingPosition = null;

    private void Awake()
    {
        currentScene = gameObject.scene.name;
        Debug.Log("----- Current scene: " + currentScene + " -----");
    }

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

    public Vector2 GetStartingPosition()
    {
        Vector2 newVector2 = new Vector2(startingPosition.position.x, startingPosition.position.y);
        return newVector2;
    }

}
