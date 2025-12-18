using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/ShopItemSO")]
public class ShopItemSO : ScriptableObject
{
    public string itemName;
    public int price;
    public Sprite icon;
    public ItemSO itemSO;
}
