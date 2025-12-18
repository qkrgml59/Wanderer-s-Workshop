using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [Header("UI")]
    public GameObject shopPanel;
    public Button closeButton;
    public Transform itemParent;
    public GameObject shopSlotPrefab;

    [Header("판매 아이템")]
    public List<ShopItemSO> shopItems;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        shopPanel.SetActive(false);
    }

    private void Start()
    {
        closeButton.onClick.AddListener(CloseShop);

        // 아이템 슬롯 생성
        foreach (var item in shopItems)
        {
            var slotGO = Instantiate(shopSlotPrefab, itemParent);
            var slotText = slotGO.GetComponentInChildren<TextMeshProUGUI>();
            slotText.text = $"{item.itemName}\n{item.price}G";

            var button = slotGO.GetComponent<Button>();
            button.onClick.AddListener(() => BuyItem(item));
        }
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }

    private void BuyItem(ShopItemSO shopItem)
    {
        if (PlayerStats.Instance.gold >= shopItem.price)
        {
            PlayerStats.Instance.gold -= shopItem.price;
            Inventory.Instance.AddItem(shopItem.itemSO, 1);
            Debug.Log($"[{shopItem.itemName}] 구매 완료! 골드: {PlayerStats.Instance.gold}");
        }
        else
        {
            Debug.Log("골드 부족!");
        }
    }
}
