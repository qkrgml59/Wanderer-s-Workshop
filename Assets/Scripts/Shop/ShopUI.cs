using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public ShopSlotUI[] slots;
    public ItemSO[] shopItems;
    public int[] prices;

    private void Start()
    {
        for (int i = 0; i < slots.Length && i < shopItems.Length; i++)
        {
            slots[i].Init(shopItems[i], prices[i]);
        }
    }
}
