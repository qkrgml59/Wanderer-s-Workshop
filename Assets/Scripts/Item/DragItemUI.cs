using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragItemUI : MonoBehaviour
{
    public static DragItemUI Instance;

    public Image iconImage;

    private void Awake()
    {
        Instance = this;
        iconImage.enabled= false;
    }

    public void Show(Sprite icon)
    {
        iconImage.sprite = icon;
        iconImage.enabled = true;
    }

    public void Hide()
    {
        iconImage.enabled = false;
    }

    private void Update()
    {
        if (iconImage.enabled)
        {
            iconImage.transform.position = Input.mousePosition;
        }
    }

}
