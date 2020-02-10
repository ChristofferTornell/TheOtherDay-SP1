using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consequence : MonoBehaviour
{
    private static int currentReputation = 0;

    public void REP_ChangeReputation(int difference)
    {
        currentReputation += difference;
    }

    public static int GetCurrentReputation()
    {
        return currentReputation;
    }
}
