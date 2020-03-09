using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleMouse : MonoBehaviour
{
    public static Items itemOnMouse = null;
    private static Image itemSprite;
    public static bool overInteractable = false;

    public static TextMeshProUGUI hoverText = null;

    private void Start()
    {
        itemSprite = GetComponent<Image>();
        itemSprite.sprite = null;
        itemSprite.enabled = false;

        hoverText = GetComponentInChildren<TextMeshProUGUI>();
        hoverText.text = null;
    }

    public static void SetItemOnMouse(Items item)
    {
        itemOnMouse = item;
        itemSprite.enabled = true;
        itemSprite.sprite = item.icon;
        Debug.Log("Placing " + item.name + " on mouse with " + itemSprite.name + " sprite");
    }

    public static void RemoveItem()
    {
        itemOnMouse = null;
        itemSprite.enabled = false;
        itemSprite.sprite = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !overInteractable || Input.GetKeyDown(KeyCode.Escape))
        {
            RemoveItem();
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = Input.mousePosition;
        // Place the sprite on mouse position
    }
}
