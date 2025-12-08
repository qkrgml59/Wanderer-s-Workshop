using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventorySlot
{
    [Header("슬롯에 연결된 아이템")]
    public ItemSO item;

    [Header("아이템 개수")]
    public int count;

    public void Set(ItemSO newItem, int newCount)
    {
        item = newItem;
        count = newCount;

    }

    public void Clear()
    {
        item = null;
        count = 0;
    }

    public bool IsEmpty()
    {
        return item == null || count <= 0;
    }
}
