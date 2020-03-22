using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/SceneData", order = 3)]

public class SceneData : ScriptableObject
{
    [FMODUnity.EventRef] public string sceneMusic;
    [FMODUnity.EventRef] public string sceneAmbience;
    public int footstepIndex;
    public bool hasVisited;
}
