using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // https://www.youtube.com/watch?v=MMH4kFknQ_c 

    public Transform player;
    public Transform leftBoundary;
    public Transform rightBoundary;

    public float smoothTime = 0.1f;
    private float smoothVelocity = 0;

    private float camWidth, camHeight, sceneMinX, sceneMaxX;

    void Start()
    {
        // Place the camera on the player
        gameObject.transform.position = new Vector3(player.position.x, transform.position.y, -10);
        camHeight = Camera.main.orthographicSize * 2;
        camWidth = camHeight * Camera.main.aspect;

        sceneMinX = leftBoundary.position.x + (camWidth / 2);
        sceneMaxX = rightBoundary.position.x - (camWidth / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            float playerX = Mathf.Max(sceneMinX, Mathf.Min(sceneMaxX, player.position.x));;

            float x = Mathf.SmoothDamp(transform.position.x, playerX, ref smoothVelocity, smoothTime);

            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
