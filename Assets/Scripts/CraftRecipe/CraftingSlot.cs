using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    public ItemSO item;
    public int count;

  
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
       
    }

    public void SetItem(ItemSO newItem, int newCount)
    {
        item = newItem;
        count = newCount;
      
    }

    public void Clear()
    {
        item = null;
        count = 0;
    
    }


    public RecipeIngredient ToIngredient()                              //사용자가 직접 정의하는 사용자 지정 클래스 '데이터 구조체' 
    {
        return new RecipeIngredient { item = item, count = count };
    }

 

}
