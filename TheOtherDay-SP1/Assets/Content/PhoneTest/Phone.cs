using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public Dialogue appFlashbackLockedDialogue;
    [HideInInspector]public static bool Pulled = false;
    private float PressingTime = 0;

    public GameObject SettingsPage;
    public Button SettingsButton;
    public GameObject ExitBox;

    public Button MessageButton;
    public GameObject MessagePage;

    public Button LogButton;
    public GameObject LogPage;

    public Button AlbumButton;
    public GameObject AlbumPage;

    public Button PullUpButton;
    //public Button PullDownButton;

    public Animator ani;

    [HideInInspector] public int Page = -1;

    [HideInInspector]public bool Zoomed = false;

    [FMODUnity.EventRef] public string buttonPressSound;
    [FMODUnity.EventRef] public string messageAppPressSound;
    [FMODUnity.EventRef] public string logAppPressSound;
    [FMODUnity.EventRef] public string pullUpPhoneSound;

    private void Start()
    {
        PlayerMovement.playerInstance.animator.SetBool("phone", false);
        PlayerMovement.playerMovementLocked = false;
    
        SettingsButton.onClick.AddListener(delegate { EnableSettings(true); });
        MessageButton.onClick.AddListener(delegate { EnableMessage(true); });
        LogButton.onClick.AddListener(delegate { EnableLog(true); });
        AlbumButton.onClick.AddListener(delegate { EnableAlbum(true); });
        PullUpButton.onClick.AddListener(PullUp);
        //PullDownButton.onClick.AddListener(PullDown);
    }

    bool FlashbackChecker()
    {
        if (GlobalData.instance.flashBack)
        {
            DialogueManager.instance.EnterDialogue(appFlashbackLockedDialogue);
            return true;
        }
        else
        {
            return false;
        }
    }
    void EnableSettings(bool state)
    {
        Page = 2;
        SettingsPage.SetActive(state);
    }

    void EnableMessage(bool state)
    {
        if (FlashbackChecker())
        {
            return;
        }
        Zoom(true);
        Page = 0;
        MessagePage.SetActive(state);
        FMODUnity.RuntimeManager.PlayOneShot(messageAppPressSound);
    }

    void EnableLog(bool state)
    {
        if (FlashbackChecker())
        {
            return;
        }
        Page = 1;
        LogPage.SetActive(state);
        FMODUnity.RuntimeManager.PlayOneShot(logAppPressSound);
    }

    void EnableAlbum(bool state)
    {
        if (FlashbackChecker())
        {
            return;
        }
        AlbumPage.SetActive(state);
    }

    private bool hasOpenedPhone = false;
    private void PullUp()
    {
        PressingTime = 0;
        ani.Play("Up");
        Pulled = true;
        PlayerMovement.playerInstance.animator.SetBool("phone", true); // Riley tar upp telefonen
        PlayerMovement.playerMovementLocked = true; // Och kan inte röra sig när den är uppe

        //PullDownButton.gameObject.SetActive(true);
        if (HotelEvents.instance != null && !hasOpenedPhone)
        {
            HotelEvents.instance.CheckEvent(10);
            hasOpenedPhone = true;
        }
        PullUpButton.gameObject.SetActive(false);
        FMODUnity.RuntimeManager.PlayOneShot(pullUpPhoneSound);

    }

    public void Zoom(bool state)
    {
        if (state)
        {
            ani.Play("Zoom In");
            Zoomed = true;
        }
        else
        {
            ani.Play("Zoom out");
            Zoomed = false;
        }
    }

    public void ExitGame()
    {
        Instantiate(ExitBox, new Vector3(455, 200, 0), Quaternion.identity).transform.parent = gameObject.transform;
    }

    private void Update()
    {
        PressingTime += Time.deltaTime;
        if (!Pulled)
        {
            PullUpButton.gameObject.SetActive(true);
        }
        else
        {
            PullUpButton.gameObject.SetActive(false);
        }
    }
}