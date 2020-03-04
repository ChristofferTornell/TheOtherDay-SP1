using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animator = null;
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
        if (animator) animator.SetTrigger("Fade In");

        yield return new WaitForSeconds(sceneChangeDelay);

        if (animator) animator.ResetTrigger("Fade In");
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
