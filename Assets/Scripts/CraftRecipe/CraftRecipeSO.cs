using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Crafting/Recipe")]

public class CraftRecipeSO : ScriptableObject
{
    [Header("필요 재료 (아이템 + 개수")]
    public List<RecipeIngredient> ingredients = new List<RecipeIngredient>();

    [Header("결과 아이템")]
    public ItemSO resultItem;
    public int resultCount = 1;


   
}
