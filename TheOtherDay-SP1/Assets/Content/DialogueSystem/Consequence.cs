using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Consequence : ScriptableObject
{
    [SerializeField] private int startingReputation;
    private static int currentReputation = 0;

    private void Start()
    {
        currentReputation = startingReputation;
    }

    public void REP_ChangeReputation(int difference)
    {
        currentReputation += difference;
    }

    public static int GetCurrentReputation()
    {
        return currentReputation;
    }
}
