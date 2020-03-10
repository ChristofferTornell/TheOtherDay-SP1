using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static GlobalData instance;
    public int stage = 0;
    public bool flashBack;
    public SceneData[] sceneDataList;
    public CharacterData[] charaters;
    public int reputation = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        foreach (SceneData sData in sceneDataList)
        {
            if (sData != null)
            {
                sData.hasVisited = false;

            }
        }
        foreach(CharacterData cData in charaters)
        {
            foreach (DialogueContainer dContainer in cData.dialogues)
            {
                dContainer.hasSpoken = false;
                dContainer.hasSpokenFlashback = false;
            }
        }
    }
}
