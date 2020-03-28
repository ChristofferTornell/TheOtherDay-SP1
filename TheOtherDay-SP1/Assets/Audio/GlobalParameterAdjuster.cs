using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParameterAdjuster : MonoBehaviour
{
    [FMODUnity.ParamRef] public string InFoyerParameter;

    private void Start()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(InFoyerParameter, 1f);
    }
    private void OnDestroy()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(InFoyerParameter, 0f);
    }
}
