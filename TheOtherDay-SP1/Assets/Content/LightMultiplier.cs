using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightMultiplier : MonoBehaviour
{
    // Easy access to changing the light multiplier from other classes
    // On changing the values. The LightMultiplier Script on all lights takes the new change

    public UnityAction<float> onLightChange = delegate { };

    Light2D light2D = null;
    public static float lightIntensityMultiplier = 1;

    public void ChangeLight(float amount)
    {
        lightIntensityMultiplier += amount;
        light2D.intensity = light2D.intensity * lightIntensityMultiplier;
    }

    private void Start()
    {
        if (GetComponent<Light2D>())
        {
            light2D = GetComponent<Light2D>();

            light2D.intensity = light2D.intensity * lightIntensityMultiplier;
        }
    }
}
