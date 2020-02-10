using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Position
{
    public Scene scene;
    public Vector2 position;
}

public class SavedPositions
{
    private static List<Position> savedPositions = new List<Position>();

    public static void NewPosition(Scene scene, Vector2 position)
    {
        // If creating new position in a scene that is already in the list, overwrite the postion in it
        for (int i = 0; i < savedPositions.Count; i++)
        {
            if (savedPositions[i].scene == scene)
            {
                savedPositions[i].position = position;
                Debug.Log("SavedPositions - Overwriting position in " + scene.name + " with " + position);
                return;
            }
        }

        Debug.Log("SavedPosition - Creating new position in " + scene);
        Position newPosition = new Position();
        newPosition.scene = scene;
        newPosition.position = position;
        savedPositions.Add(newPosition);
    }

    public static Vector2 GetPosition(Scene scene)
    {
        for (int i = 0; i < savedPositions.Count; i++)
        {
            if (savedPositions[i].scene == scene)
            {
                return savedPositions[i].position;
            }
        }
        Debug.LogError("SavedPositions - Could not find saved position in " + scene);
        return Vector2.zero;
    }
}
