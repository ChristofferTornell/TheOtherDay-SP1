using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageButton : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(testing);
    }

    void testing()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
