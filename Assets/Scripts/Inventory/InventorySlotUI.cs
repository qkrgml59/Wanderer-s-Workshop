using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI countText;
    public GameObject selectFrame;

    Inventory inventory;
    InventorySlot slot;
    int index;

    public void Init(Inventory inventory, int index)
    {
        this.inventory = inventory;
        this.index = index;
    }

    public void UpdateUI(InventorySlot slot, bool selected)
    {
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

    public void OnClick()
    {
        if (slot.item == null) return;

        CraftingUI crafting = FindObjectOfType<CraftingUI>();
        if (crafting != null && crafting.gameObject.activeSelf)
        {
            crafting.SelectMaterial(slot.item);
        }
    }
}
