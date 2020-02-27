using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public SceneData sceneData;
    FMOD.Studio.EventInstance locationMusicInstance;
    FMOD.Studio.EventInstance locationAmbienceInstance;


    private void Start()
    {
        string sceneMusicEvent = sceneData.sceneMusic;
        locationMusicInstance = FMODUnity.RuntimeManager.CreateInstance(sceneMusicEvent);
        locationMusicInstance.start();

        string sceneAmbienceEvent = sceneData.sceneMusic;
        locationAmbienceInstance = FMODUnity.RuntimeManager.CreateInstance(sceneAmbienceEvent);
        locationAmbienceInstance.start();
    }
    private void OnDestroy()
    {
        locationMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        locationAmbienceInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
