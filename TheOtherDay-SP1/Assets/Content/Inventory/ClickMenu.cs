using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMenu : MonoBehaviour
{
    public GameObject Menu;
    public Button btn;
    private RectTransform menu;

    private void Start()
    {
        btn.onClick.AddListener(move);
        menu = Menu.GetComponent<RectTransform>();
    }

    void move()
    {
        Menu.transform.position = new Vector3(Input.mousePosition.x + (menu.rect.width / 2), Input.mousePosition.y + (menu.rect.height / 2), 0);
    }
}
