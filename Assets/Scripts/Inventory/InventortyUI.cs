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

        foreach (var slot in slotUIs)
            slot.UpdateUI();
    }
}
