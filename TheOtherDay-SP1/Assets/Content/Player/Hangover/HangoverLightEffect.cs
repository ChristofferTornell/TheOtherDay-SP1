using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangoverLightEffect : MonoBehaviour
{
    private bool exposureCeilingReached = false;

    public IEnumerator LightExposureEffect(float increase, float lightIncreaseTime, float stabilizationTime)
    {
        // Increase light over a set time. Then when it reahes ceiling, fade it out to normal levels
        float t = 0;
        float minIntensity = LightMultiplier.lightIntensityMultiplier;
        float maxIntensity = LightMultiplier.lightIntensityMultiplier + increase;

        if (!exposureCeilingReached)
        {
            if (t < lightIncreaseTime)
            {
                t += Time.deltaTime;
                LightMultiplier.lightIntensityMultiplier = Mathf.Lerp(minIntensity, maxIntensity, t / lightIncreaseTime);
                Debug.Log(t / lightIncreaseTime);
            }
            else { exposureCeilingReached = true; }
        }
        Debug.Log("Done");
        // Increase lightMultiplier by difference / time. Then stabilize the light multiplier to old amount over time. 
        yield return null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LightExposureEffect(0.02f, 12f, 1f));
        }
    }
}
