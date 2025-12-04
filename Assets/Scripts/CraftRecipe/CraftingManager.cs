using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public List<CraftRecipeSO> recipes;    //등록된 레시피
    public Inventory playerInventory;


    public bool TryCraft(List<RecipeIngredient> inputItems)
    {
        foreach(var recipe in recipes)
        {
            if (IsSameRecipe(recipe.ingredients, inputItems))
            {
                foreach (var ing in recipe.ingredients)                             //재료 소모
                {
                    playerInventory.RemoveItem(ing.item, ing.count);
                }

                playerInventory.AddItemMultiple(recipe.resultItem, recipe.resultCount);

                Debug.Log($"제작 성공 : {recipe.resultItem.name}");
                return true;
            }
        }

        Debug.Log("일치하느 ㄴ레시피 없음");
        return false;

    }

    bool IsSameRecipe(List<RecipeIngredient> recipe, List<RecipeIngredient>input)
    {
        if (recipe.Count != input.Count) return false;

        foreach (var r in recipe)
        {
            bool found = false;

            foreach(var i in input)
            {
                if (r.item == i.item && r.count == i.count)
                {
                    found = true;
                    break;
                }
            }
            if (!found) return false;

        }

        return true;
    }
}
