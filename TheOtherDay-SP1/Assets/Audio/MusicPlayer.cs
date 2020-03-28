﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public SceneData sceneData;
    public FMOD.Studio.EventInstance locationMusicInstance;
    public FMOD.Studio.EventInstance locationAmbienceInstance;
    public bool StartMusicOnStart_ = false;
    public bool StopMusicOnDestroy_ = false;

    public bool StartAmbienceOnStart_ = false;
    public bool StopAmbienceOnDestroy_ = false;
    public static MusicPlayer instance;

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

    public void PlaySceneMusic()
    {
        string sceneMusicEvent = sceneData.sceneMusic;
        locationMusicInstance = FMODUnity.RuntimeManager.CreateInstance(sceneMusicEvent);
        locationMusicInstance.start();
    }
    public void ResetToNewMusic(string _sceneMusic)
    {
        if (_sceneMusic == "none")
        {
            Debug.Log("sceneMusic null");
            return;
        }
        locationMusicInstance = FMODUnity.RuntimeManager.CreateInstance(_sceneMusic);
        locationMusicInstance.start();
    }
    public void PlaySceneAmbience()
    {
        string sceneAmbienceEvent = sceneData.sceneAmbience;
        locationAmbienceInstance = FMODUnity.RuntimeManager.CreateInstance(sceneAmbienceEvent);
        locationAmbienceInstance.start();
    }
    public void ResetToNewAmbience(string _sceneAmbience)
    {
        if (_sceneAmbience == "none")
        {
            Debug.Log("sceneAmbience null");
            return;
        }
        locationAmbienceInstance = FMODUnity.RuntimeManager.CreateInstance(_sceneAmbience);
        locationAmbienceInstance.start();
    }
    public void AdjustParameterOnCurrentAudio(string parameterName, float parameterValue)
    {
        Debug.Log("adjust: " + locationMusicInstance + ", value: " + parameterValue);
        locationMusicInstance.setParameterByName(parameterName, parameterValue);
        locationAmbienceInstance.setParameterByName(parameterName, parameterValue);
    }
}
