using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float sceneChangeDelay = 1f;
    public static SceneChanger instance;
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

        yield return new WaitForSeconds(sceneChangeDelay);

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
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
        GlobalData.instance.flashBack = true;
    }

    public void ExitFlashback(string sceneName)
    {
        Debug.Log("Interactable - Returning to present: " + sceneName);
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
        GlobalData.instance.flashBack = false;
    }
}
