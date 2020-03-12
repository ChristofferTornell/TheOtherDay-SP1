using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public GameObject vomitSprite = null;
    public void PrintEvent()
    {
        Debug.Log("PrintEvent");
    }

    public void InstantiateVomit(float x, float y)
    {
        GameObject vomit = Instantiate(vomitSprite, new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, gameObject.transform.position.z), Quaternion.identity);        
    }
}
