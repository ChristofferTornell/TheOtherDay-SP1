using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    public int myId;
    public Dialogue currentDialogue;
    public Button button;
    private Image imageComponent;
    private float alpha = 1f;
    public float alphaDecrease = 0.1f;
    private Color originColor;

    void Awake()
    {
        imageComponent = button.GetComponent<Image>();
        originColor = textObject.color;
    }
    void Start()
    {
        currentDialogue = DialogueManager.instance.currentDialogue;
        alpha = 1f;
    }

    public void GoToNextDialogue()
    {
        DialogueManager.instance.currentDialogue = currentDialogue.choiceButtons[myId].nextDialogue;
        DialogueManager.instance.dialogueBoxUI.TakeNewDialogue();
    }

    void Update()
    {
        alpha -= alphaDecrease * Time.deltaTime;
        Color newColor = new Color(1f, 1f, 1f, alpha);
        imageComponent.color = newColor;
        textObject.color = new Color(originColor.r, originColor.g, originColor.b, alpha);
    }
}
