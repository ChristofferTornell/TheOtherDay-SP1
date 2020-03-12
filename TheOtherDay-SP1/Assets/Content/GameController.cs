using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//public enum CursorSprite { SmallPointer, BigPointer, SmallGlass, BigGlass, SmallHand, BigHand }

public enum CursorSprite { Pointer, MagnifyingGlass, Hand }

public class GameController : MonoBehaviour
{
    public static bool pause = false;
    public static string currentScene;
    public CursorSprite defaultCursor = CursorSprite.Pointer;
    public Vector2 cursorOffset = Vector2.zero;

    [Header("Cursor Textures")]
    public Texture2D pointer = null;
    public Texture2D magnifyingGlass = null;
    public Texture2D hand = null;
    [Space]

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
        ChangeCursor(defaultCursor);
    }

    public void ChangeCursor(CursorSprite cursor)
    {
        switch (cursor)
        {
            case CursorSprite.Pointer:
                Cursor.SetCursor(pointer, cursorOffset, CursorMode.ForceSoftware);
                return;

            case CursorSprite.MagnifyingGlass:
                Cursor.SetCursor(magnifyingGlass, cursorOffset, CursorMode.ForceSoftware);
                return;

            case CursorSprite.Hand:
                Cursor.SetCursor(hand, new Vector2(8, 10f), CursorMode.ForceSoftware);
                return;
        }
    }

    public void ResetCursor()
    {
        ChangeCursor(defaultCursor);
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
