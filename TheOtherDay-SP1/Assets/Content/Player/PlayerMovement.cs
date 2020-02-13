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
        //if (playerInstance == null)
        //{
        //    DontDestroyOnLoad(this);
        //    playerInstance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    void Start()
    {
        // footStepInstance = FMODUnity.RuntimeManager.CreateInstance(footStepEvent); IMPLEMENT SOUND

        originalMovementSpeed = movementSpeed;

        rb = GetComponent<Rigidbody2D>();
        if (horizontalAxis.Length == 0) { Debug.LogError("The horizontalAxis string is empty"); }

        Vector2 newPosition = SavedPositions.GetPosition(GameController.currentScene);

        if (newPosition != Vector2.zero)
        {
            Debug.Log("New Position: " + newPosition);
            transform.position = newPosition;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Vector2 newPosition = SavedPositions.GetPosition(GameController.currentScene);

        //if (newPosition != Vector2.zero)
        //{
        //    Debug.Log("New Position: " + newPosition);
        //    transform.position = newPosition;
        //}
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
        if (rb.velocity == Vector2.zero)
        {
            if (footStepInstanceActive)
            {
                footStepInstanceActive = false;
                Debug.Log("disable footstep sound");

                footStepInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }
        else
        {
            if (!footStepInstanceActive)
            {
                Debug.Log("active footstep sound");
                footStepInstanceActive = true;
                footStepInstance.start();

            }
        }
    }

    [FMODUnity.EventRef] public string footStepEvent;
    FMOD.Studio.EventInstance footStepInstance;
    private bool footStepInstanceActive;

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
                if (footStepInstanceActive)
                {
                    footStepInstanceActive = false;
                    Debug.Log("disable footstep sound");

                    footStepInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            if (footStepInstanceActive)
            {
                footStepInstanceActive = false;
                Debug.Log("disable footstep sound");

                footStepInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }
    }
}
