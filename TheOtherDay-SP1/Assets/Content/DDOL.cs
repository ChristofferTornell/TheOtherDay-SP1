using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    // TODO: Make PlayerMovement a Singleton

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
