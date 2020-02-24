using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Position
{
    public string sceneName;
    public Vector2 position;
}

public class SavedPositions
{
    private static List<Position> savedPositions = new List<Position>();

    // Called before changing scene
    public static void NewPosition(string sceneName, Vector2 position)
    {
        // If creating new position in a scene that is already in the list, overwrite the postion in it
        for (int i = 0; i < savedPositions.Count; i++)
        {
            if (savedPositions[i].sceneName == sceneName)
            {
                savedPositions[i].position = position;
                Debug.Log("SavedPositions - Overwriting position in " + sceneName + " with " + position);
                return;
            }
        }

        // Else, create a new Position and add it to the list
        Debug.Log("SavedPositions - Creating new position in " + sceneName);
        Position newPosition = new Position();
        newPosition.sceneName = sceneName;
        newPosition.position = position;
        savedPositions.Add(newPosition);
    }

    // Called after changing scene
    public static Vector2 GetPosition(string sceneName)
    {     
        // Search for a Position with sceneName and return it
        for (int i = 0; i < savedPositions.Count; i++)
        {
            if (savedPositions[i].sceneName == sceneName)
            {
                Debug.Log("SavedPositions - Getting position: " + savedPositions[i].position + " from " + sceneName);
                return savedPositions[i].position;
            }
        }

        // Else return startingPosition
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        Debug.Log("SavedPositions - Could not find saved position in " + sceneName + ", getting startingPosition: " + gameController.GetStartingPosition());
        return gameController.GetStartingPosition();
    }
}
