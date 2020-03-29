using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCinematic : MonoBehaviour
{
    [SerializeField] private string changeSceneTo = "HotelPresent";
    [FMODUnity.EventRef] public string introCinematicAudioEvent;
    FMOD.Studio.EventInstance introCinematicAudioInstance;
    private float introVideoDelay = 0.5f;

    public Sprite[] sprite;
    public float[] duration;
    private Image img;

    private void Start()
    {
        GameController.pause = true;
        introCinematicAudioInstance = FMODUnity.RuntimeManager.CreateInstance(introCinematicAudioEvent);
        img = gameObject.GetComponent<Image>();
        Invoke("StartIntroVideo", introVideoDelay);
        StartIntroAudio();
    }
    private void OnDestroy()
    {
        GameController.pause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeScene();
        }
    }
    void StartIntroAudio()
    {
        introCinematicAudioInstance.start();
    }
    void StartIntroVideo()
    {
        StartCoroutine(Intro());
    }

    void ChangeScene()
    {
        introCinematicAudioInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        GlobalData.instance.stage++;
        GlobalData.instance.logStage++;
        GlobalData.instance.flashBack = false;
        SceneChanger.instance.ChangeScene(changeSceneTo);
    }

    IEnumerator Intro()
    {
        for (int i = 0; i < sprite.Length; i++)
        {
            yield return new WaitForSeconds(duration[i]);
            if(i < sprite.Length - 1)
            {
                img.sprite = sprite[i + 1];
            }
        }
        ChangeScene();
    }
}
