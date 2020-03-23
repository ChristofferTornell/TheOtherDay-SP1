using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCinematic : MonoBehaviour
{
    [SerializeField] private string changeSceneTo = "HotelPresent";

    public Sprite[] sprite;
    public float[] duration;
    private Image img;

    private void Start()
    {
        GameController.pause = true;
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
        GlobalData.instance.stage++;
        GlobalData.instance.logStage++;
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
