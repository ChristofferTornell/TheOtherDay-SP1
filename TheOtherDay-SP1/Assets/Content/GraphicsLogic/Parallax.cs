using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject mainCamera;
    public float parallaxEffectAmount;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void FixedUpdate()
    {
        float dist = (mainCamera.transform.position.x * parallaxEffectAmount);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}
