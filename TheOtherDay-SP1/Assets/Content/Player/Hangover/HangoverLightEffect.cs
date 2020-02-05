using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangoverLightEffect : MonoBehaviour
{
    public void IncreaseLight(float amount)
    {
        LightMultiplier.lightIntensityMultiplier += amount;
    }

    public void DecreaseLight(float amount)
    {
        LightMultiplier.lightIntensityMultiplier -= amount;
    }

    public IEnumerator lightExposureEffect(float difference, float lightIncreaseTime, float stabilizationTime)
    {
        // Increase lightMultiplier by difference / time. Then stabilize the light multiplier to old amount over time. 
        yield return null;
    }
}
