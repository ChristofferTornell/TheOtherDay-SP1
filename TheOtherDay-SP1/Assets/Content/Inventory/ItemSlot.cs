using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Button btn;
    //public GameObject hideMenuButton;
    public GameObject menu;
    public Inventory inventory;

    public Items myItem = null;
    public ItemIcon myItemIcon = null;


    public float typeDelay = 1f;
    private float timerCounter = 0f;
    public float boxExitDelay = 1f;
    private bool timerTrigger = false;

    
    void Start()
    {
        btn.onClick.AddListener(Click);
    }

    void Click()
    {
        if (myItem == null)
        {
            Debug.Log("I dont have an item :(");
            return;
        }
        menu.SetActive(true);
        //hideMenuButton.SetActive(true);
        Debug.Log("You clicked me");
    }

    public void UseItem()
    {
        if(myItem.useable)
        {
            myItem.OnUse();
        }
        else
        {
            Debug.Log("You can not use this item: " + myItem);
        }
    }

    public void ExamineItem()
    {

        StartCoroutine(AutotypeText(myItem.description, typeDelay));
        inventory.descriptionBoxObj.SetActive(true);
    }

    public void ExitExamineMenu()
    {
        inventory.descriptionBoxObj.SetActive(false);
    }

    IEnumerator AutotypeText(string inputMessage, float delay)
    {

        for (int i = 0; i < inputMessage.Length; i++)
        {
            inventory.descriptionBoxDescriptionTextObj.text = inputMessage.Substring(0, i + 1);
            yield return new WaitForSeconds(delay);
        }
        timerCounter = 0f;
        timerTrigger = true;

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
