using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CursorSprite { SmallPointer, BigPointer, SmallGlass, BigGlass, SmallHand, BigHand }

public class GameController : MonoBehaviour
{
    public static bool pause = false;
    public static string currentScene;
    public static CursorSprite cursorSprite = CursorSprite.BigPointer;

    [Header("Cursor Sprites")]
    public Texture2D smallPointer = null;
    public Texture2D bigPointer = null;
    public Texture2D smallGlass = null;
    public Texture2D bigGlass = null;
    public Texture2D smallHand = null;
    public Texture2D bigHand = null;

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
        ChangeCursor(CursorSprite.BigHand);
    }

    public void ChangeCursor(CursorSprite newCursor)
    {
        cursorSprite = newCursor;
    }

    private void UpdateCursor()
    {
        switch (cursorSprite)
        {
            case CursorSprite.SmallPointer:
                Cursor.SetCursor(smallPointer, Vector2.zero, CursorMode.Auto);
                return;

            case CursorSprite.BigPointer:
                Cursor.SetCursor(bigPointer, Vector2.zero, CursorMode.Auto);
                return;

            case CursorSprite.SmallGlass:
                Cursor.SetCursor(smallGlass, Vector2.zero, CursorMode.Auto);
                return;

            case CursorSprite.BigGlass:
                Cursor.SetCursor(bigGlass, Vector2.zero, CursorMode.Auto);
                return;

            case CursorSprite.SmallHand:
                Cursor.SetCursor(smallHand, Vector2.zero, CursorMode.Auto);
                return;

            case CursorSprite.BigHand:
                Cursor.SetCursor(bigHand, Vector2.zero, CursorMode.Auto);
                return;
        }
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

    private void Update()
    {
        UpdateCursor();
    }
}
