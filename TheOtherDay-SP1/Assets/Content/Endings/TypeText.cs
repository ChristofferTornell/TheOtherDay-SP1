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

    IEnumerator AutotypeText()
    {
        foreach (Message _message in messages)
        {
            for (int i = 0; i < _message.text.Length; i++)
            {
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
}
