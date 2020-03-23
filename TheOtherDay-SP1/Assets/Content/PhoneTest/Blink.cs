using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour
{
    public float BlinkInterval = 1;
    private float BlinkTime = 0;
    public GameObject MessageDot;
    public GameObject NoteDot;
    private bool NewMessage = false;
    private bool NewNote = false;
    private Scene current;

    private void Start()
    {
        current = SceneManager.GetActiveScene();
        if(current.name == "HotelPresent")
        {
            NewMessage = true;
        }
    }

    private void Update()
    {
        if (NewMessage || NewNote)
        {
            BlinkTime += Time.deltaTime;
            if(BlinkTime > BlinkInterval)
            {
                if (NewMessage)
                {
                    MessageDot.SetActive(!MessageDot.activeSelf);
                }
                if (NewNote)
                {
                    NoteDot.SetActive(!NoteDot.activeSelf);
                }
                BlinkTime = 0;
            }
        }
        else
        {
            MessageDot.SetActive(false);
            NoteDot.SetActive(false);
        }
    }

    public void ChangeNewMessageState(bool state)
    {
        NewMessage = state;
    }
    public void ChangeNewNoteState(bool state)
    {
        NewNote = state;
    }
}
