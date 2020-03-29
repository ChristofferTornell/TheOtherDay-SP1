using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [System.Serializable]
    public class SceneAndTime
    {
        [SerializeField] private string flashbackName = null;
        [SerializeField] private FlashbackTime flashbackTime = null;

        public FlashbackTime GetSceneTime(string sceneName)
        {
            if (sceneName == flashbackName)
            {
                return flashbackTime;
            }
            else return null;
        }
    }

    public static UnityAction<SceneChanger> onChange = delegate { };

    [SerializeField] private float sceneChangeDelay = 1f;
    public static SceneChanger instance;

    [FMODUnity.EventRef] public string enterFlashbackSound;
    [FMODUnity.EventRef] public string exitFlashbackSound;

    public List<SceneAndTime> flashbackTimeList = new List<SceneAndTime>();

    private Color fadeInColor;
    private Color fadeOutColor;

    private bool flashbackTransition = false;
    private bool enteringFlashback = false;
    private bool startedTransition = false;
    private FlashbackTime flashbackTime = null;
    private bool ranOnChange = false;
    private static bool startClockOverride = false;

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
        if (sceneName == "HotelPresent" && !startClockOverride)
        {
            DigitalClockScript.minutes = 0;
            DigitalClockScript.hours = 13;
            FlashbackTransitionClock.instance.SavePresentTime(DigitalClockScript.minutes, DigitalClockScript.hours);
            startClockOverride = true;
        }

        if (PlayerMovement.playerInstance != null)
        {
            SavedPositions.NewPosition(GameController.currentScene, new Vector2(PlayerMovement.playerInstance.gameObject.transform.position.x, PlayerMovement.playerInstance.gameObject.transform.position.y));
        }

        if (!ranOnChange)
        {
            onChange(this);
            ranOnChange = true;
        }

        if (flashbackTransition)
        {          
            for (int i = 0; i < flashbackTimeList.Count; i++)
            {
                if (flashbackTimeList[i].GetSceneTime(sceneName))
                {
                    flashbackTime = flashbackTimeList[i].GetSceneTime(sceneName);
                }
            }
        }

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

        if (sceneName != "Main Menu") SceneTransition.instance.TRAN_FadeIn(fadeInColor);
        yield return new WaitForSeconds(sceneChangeDelay);
        UpdateSceneMusic(sceneName);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("Loading scene: " + sceneName);
        operation.allowSceneActivation = false;

        // When faded in:
        // Play flashbackTransition after it comes into screen from animation
        // When clock is done, reverse the animation and then change scen

        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                if (flashbackTransition)
                {
                    if (enteringFlashback)
                    {
                        if (flashbackTime && !startedTransition)
                        {
                            FlashbackTransitionClock.instance.Display(true);
                            FlashbackTransitionClock.instance.StartCoroutine(FlashbackTransitionClock.instance.TRAN_StartTransition(flashbackTime));
                            startedTransition = true;
                        }
                        else if (!flashbackTime)
                        {
                            Debug.LogError("SceneChanger - Can't find flashbackTime from: " + sceneName);
                            Debug.Log("Activating scene: " + sceneName);
                            operation.allowSceneActivation = true;
                            SceneTransition.instance.TRAN_FadeOut(fadeOutColor);
                            FlashbackTransitionClock.instance.Display(false);
                        }
                    }
                    if (!enteringFlashback && !startedTransition)
                    {
                        FlashbackTransitionClock.instance.Display(true);
                        FlashbackTransitionClock.instance.StartCoroutine(FlashbackTransitionClock.instance.TRAN_StartTransition(FlashbackTransitionClock.instance.presentTime));
                        startedTransition = true;
                    }

                    if (FlashbackTransitionClock.instance.done)
                    {
                        FlashbackTransitionClock.instance.Display(false);

                        Debug.Log("Activating scene: " + sceneName);
                        operation.allowSceneActivation = true;
                        SceneTransition.instance.TRAN_FadeOut(fadeOutColor);
                        FlashbackTransitionClock.instance.done = false;
                    }
                }

                if (!flashbackTransition)
                {
                    Debug.Log("Activating scene: " + sceneName);
                    operation.allowSceneActivation = true;
                    SceneTransition.instance.TRAN_FadeOut(fadeOutColor);
                }
            }

            yield return null;
        }

        //Play fade out when the operation is coplmete

        //if (operation.isDone) SceneTransition.instance.TRAN_FadeOut(fadeOutColor);

        //SceneManager.LoadScene(sceneName);

        yield return null;
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("SceneChanger - Changing Scene to: " + sceneName);
        flashbackTransition = false;
        enteringFlashback = false;
        FlashbackTransitionClock.instance.flashback = false;
        FlashbackTransitionClock.instance.SavePresentTime(DigitalClockScript.minutes, DigitalClockScript.hours);
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
    }

    public void EnterFlashback(string sceneName)
    {
        Debug.Log("SceneChanger - Entering flashback: " + sceneName);
        FMODUnity.RuntimeManager.PlayOneShot(enterFlashbackSound);
        flashbackTransition = true;
        enteringFlashback = true;
        FlashbackTransitionClock.instance.flashback = true;
        FlashbackTransitionClock.instance.SavePresentTime(DigitalClockScript.minutes, DigitalClockScript.hours);
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
    }

    public void ExitFlashback(string sceneName)
    {
        Debug.Log("SceneChanger - Returning to present: " + sceneName);
        FMODUnity.RuntimeManager.PlayOneShot(exitFlashbackSound);
        GlobalData.instance.stage++;
        Notes.instance.ProgressToNextEntry();
        flashbackTransition = true;
        enteringFlashback = false;
        FlashbackTransitionClock.instance.flashback = false;
        StartCoroutine(CoChangeScene(sceneName));
        GameController.Pause(true);
    }
    private void UpdateSceneMusic(string sceneName)
    {
        if (GlobalData.instance != null)
        {
            string nextMusic = GlobalData.instance.GetMusicInScene(sceneName);
            string nextAmbience = GlobalData.instance.GetAmbienceInScene(sceneName);
            if (MusicPlayer.instance != null)
            {
                Debug.Log("Next music: " + nextMusic + ", Current music: " + GlobalData.instance.GetMusicInScene(SceneManager.GetActiveScene().name));

                if (nextMusic != GlobalData.instance.GetMusicInScene(SceneManager.GetActiveScene().name))
                {
                    MusicPlayer.instance.locationMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    MusicPlayer.instance.ResetToNewMusic(nextMusic);
                }
                if (nextAmbience != GlobalData.instance.GetAmbienceInScene(SceneManager.GetActiveScene().name))
                {
                    MusicPlayer.instance.locationAmbienceInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    MusicPlayer.instance.ResetToNewAmbience(nextAmbience);
                }
            }
        }
    }
}
