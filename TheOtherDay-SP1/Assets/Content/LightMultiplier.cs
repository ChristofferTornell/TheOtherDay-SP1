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
    // https://stackoverflow.com/questions/46419975/increase-and-decrease-light-intensity-overtime 

    Light2D light2D = null;
    public static float lightIntensityMultiplier = 1;

    private void Start()
    {
        if (GetComponent<Light2D>())
        {
            light2D = GetComponent<Light2D>();

            light2D.intensity = light2D.intensity * lightIntensityMultiplier;
        }
    }

    // Effect that will play when first exposed to the lights
    // Increase light intensity and then fade out overtime.
    public IEnumerator LightExposureEffect(float increase, float lightIncreaseTime, float stabilizationTime)
    {
        // Increase light over a set time. Then when it reahes ceiling, fade it out to normal levels
        float t = 0;
        float minIntensity = lightIntensityMultiplier;
        float maxIntensity = lightIntensityMultiplier + increase;

        while (t < lightIncreaseTime)
        {
            t += Time.deltaTime;
            lightIntensityMultiplier = Mathf.Lerp(minIntensity, maxIntensity, t / lightIncreaseTime);
            light2D.intensity = light2D.intensity * lightIntensityMultiplier;
            Debug.Log(lightIntensityMultiplier);
        }
        Debug.Log("Done");
        // Increase lightMultiplier by difference / time. Then stabilize the light multiplier to old amount over time. 
        yield return null;
    }

    // Effect that will act as the annoyance for the player due to hangover
    public IEnumerator RepeatingLightChanges()
    {
        // Increase and decrease light over randomized time, repeat
        yield return null;
    }

    private void Update()
    {
        light2D.intensity = light2D.intensity * lightIntensityMultiplier;

        if (Input.GetKeyDown(KeyCode.L))
        {
            //StartCoroutine(LightExposureEffect(0.02f, 12f, 1f));
        }
    }
}