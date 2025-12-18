using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotUI : MonoBehaviour
{
    public Image icon;
    public Text priceText;
    public Button buyButton;

    private ItemSO item;
    private int price;

    public void Init(ItemSO item, int price)
    {
        this.item = item;
        this.price = price;
        icon.sprite = item.icon;
        icon.enabled = true;
        priceText.text = price.ToString();
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        // 플레이어가 충분한 골드가 있으면
        if (PlayerStats.Instance.gold >= price)
        {
            PlayerStats.Instance.AddGold(-price);
            Inventory.Instance.AddItem(item, 1); // 인벤토리에 1개 추가
            Debug.Log($"구매 완료: {item.itemName}");
        }
        else
        {
            Debug.Log("골드 부족!");
        }
    }
}
