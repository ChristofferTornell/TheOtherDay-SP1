using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    [Tooltip("Movement speed of the player (recommended value between 350 - 500)")]
    [SerializeField] private float movementSpeed = 450;

    private Rigidbody2D rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void PlayerInput()
    {
        rb.velocity = Vector2.zero;

        // Right
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = Vector2.right * movementSpeed * Time.deltaTime;
        }

        // Left
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = Vector2.left * movementSpeed * Time.deltaTime;
        }
    }

    void Update()
    {
        PlayerInput();
    }
}
