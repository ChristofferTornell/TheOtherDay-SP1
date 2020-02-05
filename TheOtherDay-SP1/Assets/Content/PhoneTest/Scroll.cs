using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public Rigidbody2D body;
    [HideInInspector]
    public float initX;
    [HideInInspector]
    public float initY;

    private void Start()
    {
        initX = transform.position.x;
        initY = transform.position.y;
    }
    void Update()
    {
        body.velocity = new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * Mathf.Pow(10, 4), 0);
    }
}
