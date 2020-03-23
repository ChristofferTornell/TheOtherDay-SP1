using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    public static Notes instance = null;
    public TextMeshProUGUI[] textObjects;
    public GameObject page1Entries;
    public GameObject page2Entries;
    public Button forwardButton;
    public Button backButton;

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

    void Start()
    {
        GiveTextObj();
        InitializeLog();
    }

    void GiveTextObj()
    {
        for (int i = 0; i < GlobalData.instance.logEntries.Length; i++)
        {
            GlobalData.instance.logEntries[i].textObj = textObjects[i];
        }
    }

    void InitializeLog()
    {
        for (int i = 0; i < GlobalData.instance.logEntries.Length; i++)
        {
            GlobalData.instance.logEntries[i].textObj.text = "* " + GlobalData.instance.logEntries[i].message;
            // Den här debuggen fyllde konsolen, tänker den kanske inte används längre heller så jag kommenterar bort den för tillfället
            //Debug.Log(GlobalData.instance.logEntries[i].textObj.transform.localPosition);
            GlobalData.instance.logEntries[i].index = i;
            if (i == 0)
            {
                Debug.Log("showing first entry");
                ShowEntry(GlobalData.instance.logEntries[i]);
            }
            if (GlobalData.instance.logEntries[i].complete)
            {
                EntryComplete(GlobalData.instance.logEntries[i]);
            }
        }
    }
    
    public void ProgressToNextEntry()
    {
        GlobalData.instance.logStage++;
        if (GlobalData.instance.logStage < GlobalData.instance.logEntries.Length && GlobalData.instance.logStage >= 0)
        {
            EntryComplete(GlobalData.instance.logEntries[GlobalData.instance.logStage]);
        }
    }

    private void EntryComplete(LogEntry _logEntry)
    {
        _logEntry.complete = true;
        _logEntry.textObj.fontStyle = FontStyles.Strikethrough;
        if(GlobalData.instance.logEntries.Length > _logEntry.index)
        {
            LogEntry nextLogEntry = GlobalData.instance.logEntries[_logEntry.index + 1];
            ShowEntry(nextLogEntry);
        }
    }

    private void ShowEntry(LogEntry _logEntry)
    {
        _logEntry.visible = true;
        _logEntry.textObj.gameObject.SetActive(true);
    }

    /*
    public void EnableNextNote()
    {
        if (stage < Note.Length - 1)
        {
            stage++;
            Note[stage].gameObject.SetActive(true);
        }
    }
    */
}
