using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InMessage : MonoBehaviour
{
    private CharacterData character;
    public TextMeshProUGUI[] sms;
    public int stage = 0;

    void Start()
    {
        character = GetComponentInParent<MessageSquare>().character;
        for (int i = 0; i < sms.Length; i++)
        {
            sms[i].text = character.sms[i];
        }
        UpdateTexts(false);
    }

    public void UpdateTexts(bool update)
    {
        if (update)
        {
            stage++;
        }
        for (int i = 0; i <= stage; i++) //om man ska börja med att ha sms så ska man ha i <= stage
        {
            if(i <= stage)
            {
                sms[i].transform.parent.gameObject.SetActive(true);
                sms[i].transform.parent.position = new Vector3(sms[i].transform.parent.position.x, sms[i].transform.parent.position.y + (50 * (stage - i)), 0);
            }
        }
    }
}
