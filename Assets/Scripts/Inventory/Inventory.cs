using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public int bigSlotCount = 18;
    public int quickSlotCount = 6;

    public static Inventory Instance;

    public List<InventorySlot> slots = new();

    public int selectedSlotIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        for (int i = 0; i < bigSlotCount; i++)
            slots.Add(new InventorySlot());
    }

    public bool AddItem(ItemSO item, int amount)
    {
      
        foreach (var slot in slots)
        {
            if (slot.item == item && slot.count < item.maxStack)
            {
                slot.count += amount;
                return true;
            }
        }
       foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = item;
                slot.count = amount;
                return true;
            }
        }

        return false;
    }

    public bool HasItem(ItemSO item, int count)
    {
        int total = 0;
        foreach (var slot in slots)
        {
            if (slot.item == item)
                total += slot.count;
        }
        return total >= count;
    }

    public void RemoveItem(ItemSO item, int count)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == item)
            {
                int remove = Mathf.Min(count, slots[i].count);
                slots[i].count -= remove;
                count -= remove;

                if (slots[i].count <= 0)
                    slots[i].item = null;

                if (count <= 0) return;
            }
        }
    }
}
