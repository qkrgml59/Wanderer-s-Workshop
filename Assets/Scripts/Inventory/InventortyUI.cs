using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventortyUI : MonoBehaviour
{
    public Inventory inventory;
    public InventorySlotUI[] slotUIs;
    public GameObject inventoryPanel;

    private void Start()
    {
        inventoryPanel.SetActive(false);

        for (int i = 0; i < slotUIs.Length; i++)
            slotUIs[i].Init(inventory, i);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Å° ´­¸²");
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }

        for (int i = 0; i < slotUIs.Length; i++)
        {
            slotUIs[i].UpdateUI(
                inventory.slots[i],
                inventory.selectedSlotIndex == i
            );
        }
    }

    public void SetBigInventory(bool open)
    {
        inventoryPanel.SetActive(open);
    }


}
