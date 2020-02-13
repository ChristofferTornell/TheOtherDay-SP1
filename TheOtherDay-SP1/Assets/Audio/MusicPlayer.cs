using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public SceneData sceneData;
    FMOD.Studio.EventInstance locationMusicInstance;

    private void Start()
    {
        string sceneMusicEvent = sceneData.sceneMusic;
        locationMusicInstance = FMODUnity.RuntimeManager.CreateInstance(sceneMusicEvent);
        locationMusicInstance.start();
    }
    private void OnDestroy()
    {
        locationMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
