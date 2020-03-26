using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCinematic : MonoBehaviour
{
    [SerializeField] private string changeSceneTo = "HotelPresent";
    [FMODUnity.EventRef] public string introCinematicAudioEvent;
    FMOD.Studio.EventInstance introCinematicAudioInstance;

    public Sprite[] sprite;
    public float[] duration;
    private Image img;

    private void Start()
    {
        GameController.pause = true;
        introCinematicAudioInstance = FMODUnity.RuntimeManager.CreateInstance(introCinematicAudioEvent);
        introCinematicAudioInstance.start();
        img = gameObject.GetComponent<Image>();
        StartCoroutine(Intro());
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
