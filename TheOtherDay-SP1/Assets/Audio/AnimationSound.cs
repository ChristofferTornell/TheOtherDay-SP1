using UnityEngine;

public class AnimationSound : MonoBehaviour
{
    [FMODUnity.EventRef] public string rileyVomitSound;
    public void PlayVomitSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(rileyVomitSound);
    }
}

