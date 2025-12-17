using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ItemSO item;
    public int count;

    public void Clear()
    {
        item = null;
        count = 0;
    }
}
