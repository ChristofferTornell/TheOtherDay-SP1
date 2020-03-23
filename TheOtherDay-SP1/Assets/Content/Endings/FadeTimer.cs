using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeTimer : MonoBehaviour
{
    private float Counter = 0;
    public Image image;
    public TextMeshProUGUI text;
    public float time;
    private float Alpha = 1;
    public float FadeRate = 0.005f;
    [FMODUnity.EventRef] public string onFadeCompleteSound;
    private bool soundTrigger = false;

    private void Start()
    {
        if(image != null)
        {
            Alpha = 1;
        }
        else if(text != null)
        {
            Alpha = 0;
            text.color = new Color(1, 1, 1, 0);
        }
    }

    private void Update()
    {
        Counter += Time.deltaTime;
        if (Counter > time && image != null)
        {
            if(image.color.a != 0)
            {
                Alpha -= FadeRate;
                image.color = new Color(1, 1, 1, Alpha);
            }
            else
            {
                if (!soundTrigger && onFadeCompleteSound != "")
                {
                    soundTrigger = true;
                    FMODUnity.RuntimeManager.PlayOneShot(onFadeCompleteSound);
                }
            }
        }
        else if (Counter > time && text != null)
        {
            if(text.color.a != 1)
            {
                Alpha += FadeRate;
                text.color = new Color(1, 1, 1, Alpha);
            }
        }
    }
}
