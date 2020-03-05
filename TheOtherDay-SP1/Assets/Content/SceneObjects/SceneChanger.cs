using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animator = null;
    [SerializeField] private float sceneChangeDelay = 1f;
    public static SceneChanger instance;

    private Color fadeInColor;
    private Color fadeOutColor;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator CoChangeScene(string sceneName)
    {
        // Scene change effect(s) can be put here
        // --------------------------------------

        if (sceneName == "CityPresent")
        {
            fadeInColor = Color.gray;    
            fadeOutColor = Color.gray;    
        }

        else
        {
            fadeInColor = Color.black;
            fadeOutColor = Color.black;
        }

        SceneTransition.instance.TRAN_FadeIn(fadeInColor);

        yield return new WaitForSeconds(sceneChangeDelay);

        SceneTransition.instance.TRAN_FadeOut(fadeOutColor);

        SceneManager.LoadScene(sceneName);

        yield return null;
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("Interactable - Changing Scene to: " + sceneName);
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
    }

    public void EnterFlashback(string sceneName)
    {
        Debug.Log("Interactable - Entering flashback: " + sceneName);
        GlobalData.instance.flashBack = true;
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
    }

    public void ExitFlashback(string sceneName)
    {
        Debug.Log("Interactable - Returning to present: " + sceneName);
        GlobalData.instance.stage++;
        GlobalData.instance.flashBack = false;
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
    }
}
