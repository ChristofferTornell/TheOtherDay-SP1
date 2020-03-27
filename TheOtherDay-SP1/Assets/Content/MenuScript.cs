using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void QuitToDesktop()
    {
        Debug.Log("Quitting to desktop!");
        Application.Quit();
    }

    public void QuitToMainMenu()
    {
        Debug.Log("Quitting to main menu");
        SceneManager.LoadScene("Main Menu");
    }
    public void ResetStages()
    {
        GlobalData.instance.ResetStages();
    }
}
