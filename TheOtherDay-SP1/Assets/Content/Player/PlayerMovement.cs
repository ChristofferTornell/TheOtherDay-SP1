using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("The string name of the axis at Edit -> Project Settings -> Input")]
    [SerializeField] private string horizontalAxis = "Horizontal";

    [Header("Stats")]
    [Tooltip("Movement speed of the player (recommended value between 350 - 500)")]
    [SerializeField] private float movementSpeed = 450;
    private Rigidbody2D rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (horizontalAxis.Length == 0) { Debug.LogError("The horizontalAxis string is empty"); }
    }

    void PlayerInput()
    {
        rb.velocity = Vector2.zero;

        // Right
        if (Input.GetAxisRaw(horizontalAxis) > 0)
        {
            rb.velocity = Vector2.right * movementSpeed * Time.deltaTime;
        }

        // Left
        if (Input.GetAxisRaw(horizontalAxis) < 0)
        {
            rb.velocity = Vector2.left * movementSpeed * Time.deltaTime;
        }
    }

    void Update()
    {
        PlayerInput();
    }
}
