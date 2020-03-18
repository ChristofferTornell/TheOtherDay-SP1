using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BackButton : MonoBehaviour
{
    public static BackButton instance;
    public Phone phone;
    public Button _HomeButton;
    public Button _BackButton;
    public Button _OutsideButton;
    public List<GameObject> MessageMenus;
    public GameObject GennyMessageSquare;
    public GameObject LogMenu;
    private GameObject[] MessageBubbles;
    public GameObject SettingsMenu;

    private GameObject parent;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        _HomeButton.onClick.AddListener(HomeButton);
        _BackButton.onClick.AddListener(BackbuttonFunc);
        _OutsideButton.onClick.AddListener(OutsideButton);
        //vp.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        //vp.playbackSpeed = 0;
        parent.SetActive(false);
    }

    private void HomeButton()
    {
        if (phone.Page == 0)
        {
            if(MessageBubbles != null)
            {
                ResetMessages();
            }
            for (int i = MessageMenus.Count - 1; i >= 0; i--)
            {
                MessageMenus[i].SetActive(false);
            }
            MessageMenus.RemoveRange(1, MessageMenus.Count - 1);
            if (phone.Zoomed)
            {
                phone.Zoom(false);
            }
        }
        else if(phone.Page == 1)
        {
            LogMenu.SetActive(false);
        }
        else if(phone.Page == 2)
        {
            SettingsMenu.SetActive(false);
        }
        phone.Page = -1;
        GennyMessageSquare.SetActive(true);
    }

    private bool hasClosedPhone = false;

    public void OutsideButton()
    {
        if (DialogueManager.dialogueActive)
        {
            return;
        }
        if (phone.Page == 0)
        {
            if (MessageBubbles != null)
            {
                ResetMessages();
            }
            for (int i = MessageMenus.Count - 1; i >= 0; i--)
            {
                MessageMenus[i].SetActive(false);
            }
            MessageMenus.RemoveRange(1, MessageMenus.Count - 1);
            if (phone.Zoomed)
            {
                phone.ani.Play("Zoom out 0");
            }
        }
        else if (phone.Page == 1)
        {
            LogMenu.SetActive(false);
            phone.ani.Play("Down");
        }
        else if (phone.Page == 2)
        {
            SettingsMenu.SetActive(false);
            phone.ani.Play("Down");
        }
        else if(phone.Page == -1)
        {
            phone.ani.Play("Down");
        }
        phone.Page = -1;
        GennyMessageSquare.SetActive(true);
        Phone.Pulled = false;
        PlayerMovement.playerInstance.animator.SetBool("phone", false); // Riley lägger ner telefonen
        PlayerMovement.playerMovementLocked = false; // Och kan röra sig igen
        if (HotelEvents.instance != null)
        {
            HotelEvents.instance.CheckEvent(11);
            hasClosedPhone = true;
        }

    }

    public void AddToList(GameObject obj)
    {
        MessageMenus.Add(obj);
        if(obj.name == "In Message")
        {
            MessageBubbles = obj.GetComponent<InMessage>().TextBubbles;
            int stage = obj.GetComponent<InMessage>().stage;
            if(stage == 0)
            {
                Button[] f = obj.GetComponent<InMessage>().ForwardArrow;
                Button[] b = obj.GetComponent<InMessage>().BackArrow;
                for (int i = 0; i < f.Length; i++)
                {
                    f[i].gameObject.SetActive(false);
                    b[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void ResetMessages()
    {
        for (int i = 0; i < MessageBubbles.Length; i++)
        {
            if(i == 0)
            {
                MessageBubbles[i].SetActive(true);
            }
            else
            {
                MessageBubbles[i].SetActive(false);
            }
        }
    }
    
    private void BackbuttonFunc()
    {
        GennyMessageSquare.SetActive(true);
        if (DialogueManager.dialogueActive)
        {
            return;
        }
        if(phone.Page == 0)
        {
            if(MessageBubbles != null)
            {
                ResetMessages();
            }
            for (int i = MessageMenus.Count - 1; i >= 0; i--)
            {
                if (MessageMenus[i].activeSelf)
                {
                    MessageMenus[i].SetActive(false);
                    if(i == 0)
                    {
                        phone.Zoom(false);
                        phone.Page = -1;
                    }
                    else
                    {
                        MessageMenus.Remove(MessageMenus[i]);
                    }
                    return;
                }
            }
        }
        else if(phone.Page == 1)
        {
            LogMenu.SetActive(false);
            phone.Page = -1;
        }
        else if(phone.Page == 2)
        {
            SettingsMenu.SetActive(false);
            phone.Page = -1;
        }
    }

    private void Update()
    {
        if (Phone.Pulled)
        {
            _OutsideButton.gameObject.SetActive(true);
        }
        else
        {
            _OutsideButton.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OutsideButton();
        }
    }
}
