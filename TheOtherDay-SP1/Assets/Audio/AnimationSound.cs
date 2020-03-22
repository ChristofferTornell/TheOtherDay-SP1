using UnityEngine;

public class AnimationSound : MonoBehaviour
{
    [FMODUnity.EventRef] public string rileyVomitSound;
    [FMODUnity.EventRef] public string rileyFootstepSound;
    [FMODUnity.ParamRef] public string footStepParameter;
    [HideInInspector] public float footstepIndex = 1f;

    public void PlayFootstepSound()
    {
        FMOD.Studio.EventInstance footStepInstance = FMODUnity.RuntimeManager.CreateInstance(rileyFootstepSound);
        footStepInstance.setParameterByName(footStepParameter, footstepIndex);
        footStepInstance.start();
    }
    public void PlayVomitSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(rileyVomitSound);
    }
}

