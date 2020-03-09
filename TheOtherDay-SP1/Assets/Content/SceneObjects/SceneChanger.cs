using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static UnityAction<SceneChanger> onChange = delegate { };

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

    private void Start()
    {
        onChange += OnChange;
    }

    void OnChange(SceneChanger sceneChanger)
    {
        Debug.Log("Changing scene");
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

        onChange(this);

        if (sceneName != "Main Menu") SceneTransition.instance.TRAN_FadeIn(fadeInColor);

        yield return new WaitForSeconds(sceneChangeDelay);

        if (sceneName != "Main Menu") SceneTransition.instance.TRAN_FadeOut(fadeOutColor);

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
    }

    public void ExitFlashback(string sceneName)
    {
        Debug.Log("Interactable - Returning to present: " + sceneName);
        GlobalData.instance.stage++;
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
    }
}
