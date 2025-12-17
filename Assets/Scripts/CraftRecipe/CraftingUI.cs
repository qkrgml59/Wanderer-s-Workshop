using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    [Header("참조")]
    public Inventory inventory;
    public RecipeSO[] recipes;

    [Header("UI")]
    public GameObject panel;
    public Image matAImage;
    public Image matBImage;
    public Image resultImage;

    private ItemSO matA;
    private ItemSO matB;

    private void Start()
    {
        panel.SetActive(false);
        ClearSlots();
    }


    public void Open()
    {
        panel.SetActive(true);
        ClearSlots();
    }

    public void Close()
    {
        panel.SetActive(false);
    }


    public void SelectMaterial(ItemSO item)
    {
        if (matA == null)
        {
            matA = item;
            matAImage.sprite = item.icon;
            matAImage.enabled = true;
        }
        else if (matB == null)
        {
            matB = item;
            matBImage.sprite = item.icon;
            matBImage.enabled = true;
        }

        UpdateResult();
    }

    void UpdateResult()
    {
        resultImage.enabled = false;

        foreach (var recipe in recipes)
        {
            bool match =
                (recipe.materialA == matA && recipe.materialB == matB) ||
                (recipe.materialA == matB && recipe.materialB == matA);

            if (match)
            {
                resultImage.sprite = recipe.result.icon;
                resultImage.enabled = true;
                return;
            }
        }
    }

    public void Craft()
    {
        foreach (var recipe in recipes)
        {
            bool match =
                (recipe.materialA == matA && recipe.materialB == matB) ||
                (recipe.materialA == matB && recipe.materialB == matA);

            if (!match) continue;

            if (!inventory.HasItem(matA, 1) || !inventory.HasItem(matB, 1))
                return;

            inventory.RemoveItem(matA, 1);
            inventory.RemoveItem(matB, 1);
            inventory.AddItem(recipe.result, 1);

            QuestManager.Instance.OnCraft(recipe.result);

            ClearSlots();
            return;
        }
    }

    void ClearSlots()
    {
        matA = matB = null;

        matAImage.enabled = false;
        matBImage.enabled = false;
        resultImage.enabled = false;
    }
}
