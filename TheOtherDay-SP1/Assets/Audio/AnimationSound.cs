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
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(footStepInstance, GetComponent<Transform>(), GetComponent<Rigidbody2D>());
        footStepInstance.setParameterByName(footStepParameter, footstepIndex);
        footStepInstance.start();
    }
    public void PlayVomitSound()
    {
        FMOD.Studio.EventInstance rileyVomitInstance = FMODUnity.RuntimeManager.CreateInstance(rileyVomitSound);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(rileyVomitInstance, GetComponent<Transform>(), GetComponent<Rigidbody2D>());
        rileyVomitInstance.start();
    }
}

