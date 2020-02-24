using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float BlinkInterval = 1;
    private float BlinkTime = 0;
    public GameObject[] Target;
    
    private void Update()
    {
        BlinkTime += Time.deltaTime;
        if(BlinkTime > BlinkInterval)
        {
            for (int i = 0; i < Target.Length; i++)
            {
                Target[i].SetActive(!Target[i].activeSelf);
            }
            BlinkTime = 0;
        }
    }
}
