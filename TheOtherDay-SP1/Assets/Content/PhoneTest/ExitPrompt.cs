using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitPrompt : MonoBehaviour
{
    public Button yes;
    public Button no;

    private void Start()
    {
        if(yes != null)
        {
            yes.onClick.AddListener(Yes);
        }
        if(no != null)
        {
            no.onClick.AddListener(No);
        }
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        Destroy(gameObject);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
