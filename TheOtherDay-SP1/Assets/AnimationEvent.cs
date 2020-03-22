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

    public void InstantiateVomit()
    {
        GameObject vomit = Instantiate(vomitSprite, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z * 0), Quaternion.identity);        
    }
}
