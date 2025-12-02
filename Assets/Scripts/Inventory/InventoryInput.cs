using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    public Inventory inventory;

    void Update()
    {
        HandleSelectSlotInput(); 
    }

    void HandleSelectSlotInput()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            KeyCode key = KeyCode.Alpha1 + i;

            if (Input.GetKeyDown(key))
            {
                inventory.SelectSlot(i);
                break;
            }
        }
    }
}
