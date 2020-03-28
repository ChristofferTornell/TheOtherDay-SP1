using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [FMODUnity.EventRef] public string soundEvent;
    FMOD.Studio.EventInstance soundEventInstance;

    [FMODUnity.EventRef] public string soundEventSecondary;
    FMOD.Studio.EventInstance soundEventInstanceSecondary;

    private bool is3DSound;
    private bool is3DSoundSecondary;

    public void PlayAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(soundEvent);
    }
    public void PlayAudioSecondary()
    {
        FMODUnity.RuntimeManager.PlayOneShot(soundEventSecondary);
    }
    public void PlayAudio3D()
    {
        is3DSound = true;
        soundEventInstance.start();
    }
    public void PlayAudio3DSecondary()
    {
        is3DSoundSecondary = true;
        soundEventInstanceSecondary.start();
    }
    private void Start()
    {
        soundEventInstance = FMODUnity.RuntimeManager.CreateInstance(soundEvent);
        if(soundEventSecondary != "")
        {
            soundEventInstanceSecondary = FMODUnity.RuntimeManager.CreateInstance(soundEventSecondary);
        }
    }
    private void Update()
    {
        if(is3DSound)
        {
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundEventInstance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        }
        if (is3DSoundSecondary)
        {
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundEventInstanceSecondary, GetComponent<Transform>(), GetComponent<Rigidbody>());
        }

    }
    private void OnDestroy()
    {
        soundEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        soundEventInstanceSecondary.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
