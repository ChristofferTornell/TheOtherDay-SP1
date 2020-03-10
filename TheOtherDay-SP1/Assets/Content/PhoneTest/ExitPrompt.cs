using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPrompt : MonoBehaviour
{
    public Button yes;
    public Button no;

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        Destroy(gameObject);
    }
}
