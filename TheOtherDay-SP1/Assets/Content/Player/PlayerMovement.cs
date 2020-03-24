using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerInstance;
    public static bool playerMovementLocked = false;

    [Header("Animation")]
    public Animator animator = null;
    private Vector2 lookDirection;

    [Space]
    [Tooltip("The string name of the axis at Edit -> Project Settings -> Input")]
    [SerializeField] private string horizontalAxis = "Horizontal";

    [Header("Stats")]
    [Tooltip("Movement speed of the player")]
    [SerializeField] private float movementSpeed = 450;

    private Rigidbody2D rb = null;

    [Space]
    //[FMODUnity.EventRef] public string footStepEvent;
    //FMOD.Studio.EventInstance footStepInstance;
    private bool footStepInstanceActive;
    public AnimationSound animationSound;

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
        // footStepInstance = FMODUnity.RuntimeManager.CreateInstance(footStepEvent); IMPLEMENT SOUND

        //footStepInstance = FMODUnity.RuntimeManager.CreateInstance(footStepEvent);

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
        Vector2 newPosition = SavedPositions.GetPosition(GameController.currentScene);

        if (newPosition != Vector2.zero)
        {
            //Debug.Log("New Position: " + newPosition);
            transform.position = newPosition;
        }
        
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        animationSound.footstepIndex = musicPlayer.sceneData.footstepIndex;
    }

    void PlayerInput()
    {
        rb.velocity = Vector2.zero; 

        // Right
        if (Input.GetAxisRaw(horizontalAxis) > 0)
        {
            lookDirection = Vector2.right;
            rb.velocity = Vector2.right * movementSpeed * Time.deltaTime;

            animator.SetBool("walking", true);
            animator.SetInteger("direction", 1);             
        }

        // Left
        if (Input.GetAxisRaw(horizontalAxis) < 0)
        {
            lookDirection = Vector2.left;
            rb.velocity = Vector2.left * movementSpeed * Time.deltaTime;

            animator.SetBool("walking", true);
            animator.SetInteger("direction", 0);
        }
    }

    private void Update()
    {
        if (GlobalData.instance.flashBack) { animator.SetBool("flashback", true); }
        else { animator.SetBool("flashback", false); }

        if (!playerMovementLocked)
        {
            if (lookDirection == Vector2.left && Input.GetAxisRaw(horizontalAxis) == 0)
            {
                animator.SetBool("walking", false);
                animator.SetInteger("direction", 0);
            }

            if (lookDirection == Vector2.right && Input.GetAxisRaw(horizontalAxis) == 0)
            {
                animator.SetBool("walking", false);
                animator.SetInteger("direction", 1);
            }
        }
        else
        {
            animator.SetBool("walking", false);
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

                if (footStepInstanceActive)
                {
                    footStepInstanceActive = false;

                    //footStepInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            if (footStepInstanceActive)
            {
                footStepInstanceActive = false;

                //footStepInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }
    }
}
