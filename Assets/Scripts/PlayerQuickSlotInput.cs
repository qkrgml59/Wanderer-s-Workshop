using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuickSlotInput : MonoBehaviour
{
    public Inventory inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Select(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Select(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) Select(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) Select(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) Select(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) Select(5);
    }

    void Select(int index)
    {
        inventory.selectedSlotIndex = index;
    }
}
