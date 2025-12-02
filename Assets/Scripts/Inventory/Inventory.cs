using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("인벤토리 슬롯 리스트")]
    public List<InventorySlot> slots = new List<InventorySlot>();

    [Header("기본 슬롯 개수")]
    public int defaultSlotCount = 5;
   

    [Header("현재 선택된 슬롯 ")]
    public int selectedSlotIndex = 0;


    private void Awake()
    {
        //게임 시작시 기본 슬롯 생성
        for (int i = 0; i < defaultSlotCount; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    public bool AddItem(ItemSO item)      //아이템 추가
    {
       //같은 아이템이 있는지 확인
       foreach (var slot in slots)
        {
            if(slot.item == item && slot.count < item.maxStack)
            {
                slot.count++;
                return true;
            }
        }

       //빈 슬롯이 있으면 넣기
       foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = item;
                slot.count = 1;
                return true;
            }
        }

        Debug.Log("인벤토리 꽉참!");
        return false;
    }

    public void SelectSlot(int index)                  //슬롯 변경
    {
        if (index < 0 || index >= slots.Count) return;
        selectedSlotIndex = index;
        Debug.Log("현재 선택 슬롯 : " + selectedSlotIndex);
    }

    
}
