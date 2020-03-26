using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeText : MonoBehaviour
{
    public Message[] messages;
    public TextMeshProUGUI textOBJ;
    public GameObject nextButton;

    private float typeSoundCounter;
    private float typeSoundDelay = 0.1f;
    private bool typeSoundReady;
    private string typingSound = "event:/Sounds/Riley/SoundsRileyDialogue";

    IEnumerator AutotypeText()
    {
        foreach (Message _message in messages)
        {
            FMODUnity.RuntimeManager.PlayOneShot(_message.messageSound);
            for (int i = 0; i < _message.text.Length; i++)
            {
                if (typeSoundReady && _message.text[i] != ' ')
                {
                    FMODUnity.RuntimeManager.PlayOneShot(typingSound);
                    typeSoundReady = false;
                }
                textOBJ.text += _message.text[i];
                yield return new WaitForSeconds(_message.typeDelay);
            }
        }
        nextButton.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(AutotypeText());
    }
    private void Update()
    {
        if (!typeSoundReady)
        {
            typeSoundCounter += Time.deltaTime;
            if (typeSoundDelay < typeSoundCounter)
            {
                typeSoundReady = true;
                typeSoundCounter = 0;
            }
        }
    }
}
