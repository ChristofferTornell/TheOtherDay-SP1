using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notes : MonoBehaviour
{
    public TextMeshProUGUI[] Note;
    private int stage = -1;

    public void EnableNextNote()
    {
        if(stage < Note.Length - 1)
        {
            stage++;
            Note[stage].gameObject.SetActive(true);
        }
    }
}
