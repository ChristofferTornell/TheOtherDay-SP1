using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // https://www.youtube.com/watch?v=MMH4kFknQ_c 

    [Tooltip("The transform (GameObject) the camera will follow")] public Transform player;
    [Tooltip("A GameObject with Transform that will block the camera from going further left")] public Transform leftBoundary;
    [Tooltip("A GameObject with Transform that will block the camera from going further right")] public Transform rightBoundary;

    [Tooltip("The time it takes for the camera to catch up to the player in seconds")] public float smoothTime = 0.3f;
    private float smoothVelocity = 0;

    private float camWidth, camHeight, sceneMinX, sceneMaxX;
    private float originalSmoothTime;

    private void Awake()
    {
        originalSmoothTime = smoothTime;
        smoothTime = 0f;
    }

    void Start()
    {
        if (FindObjectOfType<PlayerMovement>())
        {
            player = FindObjectOfType<PlayerMovement>().transform;
        }

        // Place the camera on the player
        if (player)
        {
            gameObject.transform.position = new Vector3(player.position.x, transform.position.y, -10);
            camHeight = Camera.main.orthographicSize * 2;
            camWidth = camHeight * Camera.main.aspect;

            sceneMinX = leftBoundary.position.x + (camWidth / 2);
            sceneMaxX = rightBoundary.position.x - (camWidth / 2);
            StartCoroutine(RestoreSmoothTime(0.3f));         
        }
    }

    private IEnumerator RestoreSmoothTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        smoothTime = originalSmoothTime;
        yield return null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            float playerX = Mathf.Max(sceneMinX, Mathf.Min(sceneMaxX, player.position.x));;

            float x = Mathf.SmoothDamp(transform.position.x, playerX, ref smoothVelocity, smoothTime);

            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
