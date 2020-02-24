using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionUI : MonoBehaviour
{
    [HideInInspector] public static DescriptionUI instance;

    public GameObject descriptionBoxObj;
    public TextMeshProUGUI descriptionBoxDescriptionTextObj;

    public float typeDelay = 1f;
    private float timerCounter = 0f;
    public float boxExitDelay = 1f;
    private bool timerTrigger = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void ExamineItem(Items _item)
    {
        StartCoroutine(AutotypeText(_item.description, typeDelay));
        descriptionBoxObj.SetActive(true);
    }

    public void ExamineNPC(CharacterData _char)
    {
        StartCoroutine(AutotypeText(_char.description, typeDelay));
        descriptionBoxObj.SetActive(true);
    }
    IEnumerator AutotypeText(string inputMessage, float delay)
    {

        for (int i = 0; i < inputMessage.Length; i++)
        {
            descriptionBoxDescriptionTextObj.text = inputMessage.Substring(0, i + 1);
            yield return new WaitForSeconds(delay);
        }
        timerCounter = 0f;
        timerTrigger = true;

    }
    public void ExitExamineMenu()
    {
        descriptionBoxObj.SetActive(false);
    }

    private void Update()
    {
        if (!timerTrigger)
        {
            return;
        }

        timerCounter += Time.deltaTime;
        if (timerCounter >= boxExitDelay)
        {
            timerTrigger = false;
            timerCounter = 0f;
            ExitExamineMenu();
        }
    }
}
