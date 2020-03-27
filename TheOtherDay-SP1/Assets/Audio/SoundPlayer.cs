using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [FMODUnity.EventRef] public string soundEvent;
    FMOD.Studio.EventInstance soundEventInstance;
    private bool is3DSound;

    public void PlayAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(soundEvent);
    }
    public void PlayAudio3D()
    {
        is3DSound = true;
        soundEventInstance.start();
    }
    private void Start()
    {
        soundEventInstance = FMODUnity.RuntimeManager.CreateInstance(soundEvent);
    }
    private void Update()
    {
        if(is3DSound)
        {
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundEventInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        }
    }
    private void OnDestroy()
    {
        soundEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
