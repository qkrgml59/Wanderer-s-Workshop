using System.Collections;
using System.Collections.Generic;
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

    public bool AddItem(ItemSO item, int amount)
    {
        Debug.Log("AddItem 호출: " + item.itemName);

        foreach (var slot in slots)
        {
            if (slot.item == item && slot.count < item.maxStack)
            {
                slot.count += amount;
                Debug.Log("스택 증가");
                return true;
            }
        }

        foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = item;
                slot.count = amount;
                Debug.Log("새 슬롯에 추가");
                return true;
            }
        }

        Debug.Log("인벤토리 가득 참");
        return false;
    }
}
