﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static GlobalData instance;
    public int stage = 0;
    private int startingStage = 0;
    public bool flashBack;
    [HideInInspector] public FlashbackTime currentFlashbackTime = null;
    public SceneData[] sceneDataList;
    public CharacterData[] charaters;
    public int logStage = -2;
    private int startingLogStage = -2;
    public LogEntry[] logEntries;
    public int reputation = 0;
    private int startingReputation = 0;
    public bool clockActivated = false;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        ResetData();
    }
    public void ResetStages()
    {
        ResetData();
        reputation = startingReputation;
        logStage = startingLogStage;
        stage = startingStage;
        clockActivated = false;
    }
    public void ResetData()
    {
        foreach (SceneData sData in sceneDataList)
        {
            if (sData != null)
            {
                sData.hasVisited = false;
            }
        }
        foreach (CharacterData cData in charaters)
        {
            cData.isDrunk = false;
            foreach (DialogueContainer dContainer in cData.dialogues)
            {
                dContainer.hasSpoken = false;
                dContainer.hasSpokenFlashback = false;
            }
        }
        foreach (LogEntry lEntry in logEntries)
        {
            lEntry.visible = false;
            lEntry.complete = false;
        }
        Debug.Log("Flashback:" + instance.flashBack);
    }
    public string GetMusicInScene(string sceneName)
    {
        foreach (SceneData sData in sceneDataList)
        {
            if (sData.name == sceneName)
            {
                return sData.sceneMusic;
            }
        }
        Debug.Log("Scene doesnt have music: " + sceneName);
        return "none";
    }
    public string GetAmbienceInScene(string sceneName)
    {
        foreach (SceneData sData in sceneDataList)
        {
            if (sData.name == sceneName)
            {
                return sData.sceneAmbience;
            }
        }
        Debug.Log("Scene doesnt have ambience: " + sceneName);
        return "none";
    }
}
