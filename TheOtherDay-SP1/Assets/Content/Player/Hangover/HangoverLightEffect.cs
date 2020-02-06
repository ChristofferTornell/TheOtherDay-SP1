using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangoverLightEffect : MonoBehaviour
{
    public IEnumerator lightExposureEffect(float difference, float lightIncreaseTime, float stabilizationTime)
    {
        // Increase lightMultiplier by difference / time. Then stabilize the light multiplier to old amount over time. 
        yield return null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
        }
    }
}
