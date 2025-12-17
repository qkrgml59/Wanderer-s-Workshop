using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Crafting/Recipe")]
public class RecipeSO : ScriptableObject
{
    public ItemSO materialA;
    public ItemSO materialB;
    public ItemSO result;
}
