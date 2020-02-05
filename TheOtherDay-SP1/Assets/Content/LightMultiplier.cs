using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightMultiplier : MonoBehaviour
{
    public static float lightIntensityMultiplier = 1f;
    Light2D light2D = null;

    private void Start()
    {
        if (GetComponent<Light2D>())
        {
            light2D = GetComponent<Light2D>();

            light2D.intensity = light2D.intensity * lightIntensityMultiplier;
        }
    }

    private void Update()
    {
        //light2D.intensity = light2D.intensity * lightIntensityMultiplier;
    }
}
