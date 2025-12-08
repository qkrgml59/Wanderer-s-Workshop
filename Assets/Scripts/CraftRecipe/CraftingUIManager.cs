using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUIManager : MonoBehaviour
{
    public static CraftingUIManager Instance;

    [Header("UI 패널")]
    public GameObject craftingPanel;     //작업대 UI

    [Header("슬롯들")]
    public CraftingSlotUI[] craftingSlots;

    [Header("참조")]
    public CraftingManager craftingManager;

    private void Awake()
    {
        Instance = this;
    }

    public void CloseUI()
    {
        craftingPanel.SetActive(false);
    }

    public void ToggleUI()
    {
        craftingPanel.SetActive(!craftingPanel.activeSelf);
        RefreshAllSlots();
    }

    public void RefreshAllSlots()
    {
        foreach (var s in craftingSlots)
            s.RefreshUI();
    }

    public void OnClickCraftButton()
    {
        List<RecipeIngredient> inputList = new List<RecipeIngredient>();

        foreach (var slot in craftingSlots)
        {
            if (slot.craftingSlot.item != null && slot.craftingSlot.count > 0)
            {
                inputList.Add(new RecipeIngredient()
                {
                    item = slot.craftingSlot.item,
                    count = slot.craftingSlot.count
                });
            }
        }

        bool success = craftingManager.TryCraft(inputList);

        if (success)
        {
            ClearAllCraftingSlots();
            RefreshAllSlots();
        }
        else
        {
            Debug.Log("레시피가 일치하지 않음");
        }
    }


    public void ClearAllCraftingSlots()
    {
        foreach (var slot in craftingSlots)
        {
            slot.craftingSlot.Clear();
        
        }
    }
}
