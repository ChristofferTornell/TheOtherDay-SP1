using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InMessage : MonoBehaviour
{
    private CharacterData character;
    public TextMeshProUGUI[] sms;
    public Button[] BackArrow;
    public Button[] ForwardArrow;
    public GameObject[] TextBubbles;
    public int stage = 0;

    void Start()
    {
        character = GetComponentInParent<MessageSquare>().character;
        for (int i = 0; i < sms.Length; i++)
        {
            sms[i].text = character.sms[i];
        }
        for (int i = 0; i < BackArrow.Length; i++)
        {
            //BackArrow[i].onClick.AddListener(delegate { UpdateTexts(ForwardArrow[i]); });
            //ForwardArrow[i].onClick.AddListener(delegate { UpdateTexts(ForwardArrow[i]); });
        }
    }

    public void UpdateStage()
    {
        stage++;
    }

    public void UpdateTexts(Button btn)
    {
        for (int i = 0; i <= stage; i++)
        {
            if(ForwardArrow[i] == btn)
            {
                TextBubbles[i].SetActive(false);
                TextBubbles[i + 1].SetActive(true);
                if(i == stage - 1)
                {
                    ForwardArrow[i + 1].gameObject.SetActive(false);
                    BackArrow[i + 1].gameObject.SetActive(true);
                }
                else
                {
                    BackArrow[i + 1].gameObject.SetActive(true);
                    ForwardArrow[i + 1].gameObject.SetActive(true);
                }
                return;
            }
            else if(BackArrow[i] == btn)
            {
                TextBubbles[i].SetActive(false);
                TextBubbles[i - 1].SetActive(true);
                if(i == 1)
                {
                    BackArrow[i - 1].gameObject.SetActive(false);
                    ForwardArrow[i - 1].gameObject.SetActive(true);
                }
                else
                {
                    BackArrow[i - 1].gameObject.SetActive(true);
                    ForwardArrow[i - 1].gameObject.SetActive(true);
                }
                return;
            }   
        }
    }

    private void OnValidate()
    {
        if(stage >= character.sms.Length)
        {
            stage = character.sms.Length - 1;
        }
        else if(stage < 0)
        {
            stage = 0;
        }
    }
}
