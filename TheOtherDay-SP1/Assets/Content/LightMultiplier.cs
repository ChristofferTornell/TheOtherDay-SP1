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

    public static UnityAction<float> onLightChange = delegate { };
    // TODO - Jens: Händelseorientering

    Light2D light2D = null;
    public static float lightIntensityMultiplier = 1;

    private float t = 0;

    private void Start()
    {
        if (GetComponent<Light2D>())
        {
            light2D = GetComponent<Light2D>();

            light2D.intensity = light2D.intensity * lightIntensityMultiplier;
        }
    }

    public void OnlightChange()
    {

    }
    public IEnumerator LightExposureEffect(float increase, float lightIncreaseTime, float stabilizationTime)
    {
        if (lightIntensityMultiplier < lightIntensityMultiplier + increase)
        {
            t += Time.deltaTime;
            Mathf.Lerp(lightIntensityMultiplier, lightIntensityMultiplier + increase, t);
            light2D.intensity = light2D.intensity * lightIntensityMultiplier;
        }
        // Increase lightMultiplier by difference / time. Then stabilize the light multiplier to old amount over time. 
        yield return null;
    }

    public void ChangeLight(float amount)
    {
        lightIntensityMultiplier += amount;
        light2D.intensity = light2D.intensity * lightIntensityMultiplier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LightExposureEffect(1f, 1f, 1f));          
        }
    }
}