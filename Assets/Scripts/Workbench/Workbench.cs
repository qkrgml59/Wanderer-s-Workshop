using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBench : MonoBehaviour
{
    public CraftingUI craftingUI;
    public InventortyUI inventoryUI;

    bool isOpen = false;

    public void Toggle()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            craftingUI.Open();
            inventoryUI.SetBigInventory(true);
        }
        else
        {
            craftingUI.Close();
            inventoryUI.SetBigInventory(false);
        }
    }
}
