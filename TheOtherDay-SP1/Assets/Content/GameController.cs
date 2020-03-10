using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum CursorSprite { SmallPointer, BigPointer, SmallGlass, BigGlass, SmallHand, BigHand }

public class GameController : MonoBehaviour
{
    public static bool pause = false;
    public static string currentScene;
    public CursorSprite defaultCursor = CursorSprite.BigPointer;
    public Vector2 cursorOffset = Vector2.zero;

    [Header("Cursor Textures")]
    public Texture2D smallPointer = null;
    public Texture2D bigPointer = null;
    public Texture2D smallGlass = null;
    public Texture2D bigGlass = null;
    public Texture2D smallHand = null;
    public Texture2D bigHand = null;
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
            case CursorSprite.SmallPointer:
                Cursor.SetCursor(smallPointer, cursorOffset, CursorMode.Auto);
                return;

            case CursorSprite.BigPointer:
                Cursor.SetCursor(bigPointer, cursorOffset, CursorMode.Auto);
                return;

            case CursorSprite.SmallGlass:
                Cursor.SetCursor(smallGlass, cursorOffset, CursorMode.Auto);
                return;

            case CursorSprite.BigGlass:
                Cursor.SetCursor(bigGlass, cursorOffset, CursorMode.Auto);
                return;

            case CursorSprite.SmallHand:
                Cursor.SetCursor(smallHand, new Vector2(8, 10f), CursorMode.Auto);
                return;

            case CursorSprite.BigHand:
                Cursor.SetCursor(bigHand, new Vector2(8, 10f), CursorMode.Auto);
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
