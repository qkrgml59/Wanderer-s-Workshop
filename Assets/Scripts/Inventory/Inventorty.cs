using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int bigSlotCount = 18;
    public int quickSlotCount = 6;

    public List<InventorySlot> slots = new();

    public int selectedSlotIndex = 0;

    private void Awake()
    {
        for (int i = 0; i < bigSlotCount; i++)
            slots.Add(new InventorySlot());
    }

    public bool AddItem(ItemSO newItem, int amount)
    {
        Debug.Log("AddItem 호출: " + newItem.itemName);

        foreach (InventorySlot slot in slots)
        {
            if (slot.item == newItem)
            {
                slot.count += amount;
                Debug.Log(newItem.itemName + " 누적: " + slot.count);
                return true;
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = newItem;
                slot.count = amount;
                Debug.Log(newItem.itemName + " 새 슬롯 추가");
                return true;
            }
        }

        Debug.Log("인벤토리 꽉 참");
        return false;
    }
}
