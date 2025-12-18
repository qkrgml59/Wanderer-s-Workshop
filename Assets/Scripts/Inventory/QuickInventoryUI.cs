using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public InventorySlotUI[] slots;


    private void Start()
    {
        for (int i = 0; i<slots.Length;i++)
        {
            slots[i].Init(Inventory.Instance, i);
        }
    }
    void Update()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].UpdateUI(
                inventory.slots[i],    
                inventory.selectedSlotIndex == i
            );
        }
    }
}
