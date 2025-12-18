using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [Header("UI 참조")]
    public Image icon;
    public TextMeshProUGUI countText;
    public GameObject selectFrame;

    private Inventory inventory;
    private InventorySlot slot; // 클릭 시 사용할 슬롯
    private int index;

    // 슬롯 초기화
    public void Init(Inventory inventory, int index)
    {
        this.inventory = inventory;
        this.index = index;
    }

    // UI 갱신
    public void UpdateUI(InventorySlot slot, bool selected)
    {
        this.slot = slot; // ★ 반드시 slot 할당

        if (slot.item == null)
        {
            icon.enabled = false;
            countText.text = "";
            selectFrame?.SetActive(false);
            return;
        }

        icon.enabled = true;
        icon.sprite = slot.item.icon;
        countText.text = slot.count.ToString();

        if (selectFrame != null)
            selectFrame.SetActive(selected);
    }

    // 클릭 시 호출
    public void OnClick()
    {
        if (slot == null || slot.item == null) return;

        CraftingUI crafting = FindObjectOfType<CraftingUI>();
        if (crafting != null && crafting.gameObject.activeSelf)
        {
            crafting.SelectMaterial(slot.item);
        }
    }
}
