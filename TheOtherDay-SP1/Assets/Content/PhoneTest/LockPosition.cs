using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPosition : MonoBehaviour
{
    private float x;
    private float y;

    void Start()
    {
        x = GetComponentInParent<Scroll>().initX;
        y = GetComponentInParent<Scroll>().initY;
    }

    void Update()
    {
        transform.position = new Vector3(x, y, 0);
    }
}
