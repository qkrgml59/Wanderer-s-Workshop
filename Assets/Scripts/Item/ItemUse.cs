using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public Inventory inventory;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))    //우클릭
        {
            TryUseCurrentItem();
        }
    }

    void TryUseCurrentItem()
    {
        var slot = inventory.slots[inventory.selectedSlotIndex];
        if (slot.item == null || slot.count <=0) return;

        if (!slot.item.canUse)
        {
            Debug.Log("이 아이템은 사용할수 없습니다.");
            return;
        }

        Debug.Log(slot.item.itemName + "사용됨");

        slot.count--;
        if(slot.count <= 0)
        {
            slot.item = null;
        }
    }
}
