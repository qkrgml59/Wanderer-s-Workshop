using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI countText;

    Inventory inventory;
    int index;

    public void Init(Inventory inv, int slotIndex)
    {
        inventory = inv;
        index = slotIndex;
    }

    public void UpdateUI()
    {
        var slot = inventory.slots[index];

        if (slot.item == null)
        {
            icon.enabled = false;
            countText.text = "";
        }
        else
        {
            icon.enabled = true;
            icon.sprite = slot.item.icon;
            countText.text = slot.count.ToString();
        }
    }

    public void OnClick()
    {
        CraftingUI.Instance.TryAddMaterial(inventory.slots[index]);
    }
}
