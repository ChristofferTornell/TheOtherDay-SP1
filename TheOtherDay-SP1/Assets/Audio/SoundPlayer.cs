using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [FMODUnity.EventRef] public string soundEvent;

    public void PlayAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(soundEvent);
    }
}
