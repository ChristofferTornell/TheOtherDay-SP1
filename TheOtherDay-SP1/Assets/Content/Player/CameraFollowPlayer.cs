using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float xOffset;

    // Camera moves with player
    // If player reaches edge. Camera should stop as if colliding with the edge
    // Player should be "pushing" the camera around. A dead zone in the middle were the camera doesnt follow player.
    // Inspiration: Super Mario: World https://www.youtube.com/watch?v=TCIMPYM0AQg

    void Start()
    {
        // Place the camera on the player with offset
        gameObject.transform.position = new Vector3(player.transform.position.x + xOffset, transform.position.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x + xOffset, transform.position.y, -10);
    }
}
