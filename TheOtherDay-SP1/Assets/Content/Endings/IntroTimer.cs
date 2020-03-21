using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTimer : MonoBehaviour
{
    [SerializeField] private float videoDuration = 30f;
    private float videoCounter = 0f;
    [SerializeField] private string changeSceneTo = "HotelPresent";
    private bool timerTrigger = false;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeScene();
        }
        videoCounter += Time.deltaTime;
        if(videoCounter >= videoDuration && !timerTrigger)
        {
            ChangeScene();
        }
    }
    void ChangeScene()
    {
        timerTrigger = true;
        SceneChanger.instance.ChangeScene(changeSceneTo);
        GlobalData.instance.stage++;
        GlobalData.instance.logStage++;
    }
}
