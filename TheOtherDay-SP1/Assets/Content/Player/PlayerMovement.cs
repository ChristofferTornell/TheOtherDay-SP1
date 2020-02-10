using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement playerInstance;
    public static bool playerMovementLocked = false;

    [Tooltip("The string name of the axis at Edit -> Project Settings -> Input")]
    [SerializeField] private string horizontalAxis = "Horizontal";

    [Header("Stats")]
    [Tooltip("Movement speed of the player (recommended value around 450)")]
    [SerializeField] private float movementSpeed = 450;
    [SerializeField] private float sprintingSpeed = 500;

    private Rigidbody2D rb = null;

    private float originalMovementSpeed;

    void Awake()
    {
        if (playerInstance == null)
        {
            DontDestroyOnLoad(this);
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        originalMovementSpeed = movementSpeed;

        rb = GetComponent<Rigidbody2D>();
        if (horizontalAxis.Length == 0) { Debug.LogError("The horizontalAxis string is empty"); }

        SceneManager.sceneUnloaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene)
    {
        Vector2 newPosition = SavedPositions.GetPosition(GameController.currentScene);
        if (newPosition != Vector2.zero)
        {
            transform.position = newPosition;
        }
    }

    void PlayerInput()
    {
        rb.velocity = Vector2.zero;

        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintingSpeed;
        }
        else
        {
            movementSpeed = originalMovementSpeed;
        }

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

    void FixedUpdate()
    {
        if (!GameController.pause)
        {
            if (!playerMovementLocked)
            {
                PlayerInput();
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }
}
