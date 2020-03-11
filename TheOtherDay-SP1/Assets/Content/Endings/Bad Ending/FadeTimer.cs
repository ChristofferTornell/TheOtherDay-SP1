using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTimer : MonoBehaviour
{
    private float Counter = 0;
    public Image image;
    public float time;
    private float Alpha = 1;
    public float FadeRate = 0.005f;

    private void Update()
    {
        Counter += Time.deltaTime;
        if (Counter > time)
        {
            Alpha -= FadeRate;
            image.color = new Color(1, 1, 1, Alpha);
        }
    }
}
