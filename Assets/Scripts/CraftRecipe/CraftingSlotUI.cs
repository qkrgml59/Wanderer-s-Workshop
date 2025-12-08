using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingSlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    //I로 시작하는 인터페이스 - 이벤트를 받아서 사용하는 코드 (나중에 좀 더... 물어봐야징)
    //대신 저 인터페이스를 쓰려면 이 스크립트에 꼭 사용한 내용을 적어야 한다라고 들었던 거 같은데 자세히 기억이 안 나요.


    [Header("연결된 실제 슬롯 데이터")]
    public CraftingSlot craftingSlot;

    [Header("UI")]
    public Image itemIcon;
    public Text itemCountText;

    private GameObject dragIcon;
    private Transform canvas;

    private void Start()
    {
        canvas = GameObject.Find("Canvas").transform;
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (craftingSlot.item == null)
        {
            itemIcon.enabled = false;
            itemCountText.text = "";
        }
        else
        {
            itemIcon.enabled = true;
            itemIcon.sprite = craftingSlot.item.icon;
            itemCountText.text = craftingSlot.count.ToString();
        }
    }

    //드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (craftingSlot.item == null) return;

        dragIcon = new GameObject("DragIcon");
        dragIcon.transform.SetParent(canvas);                    //dragIcon의 부모를 canvas로 설정   <- SetParent
        dragIcon.transform.SetAsLastSibling();                  //dragIcon을 가장 마지막 순서로 변경(가장 위에 렌더링이 되도록)    <- SetAsLastSibling

        Image img = dragIcon.AddComponent<Image>();
        img.sprite = craftingSlot.item.icon;
        img.raycastTarget = false;

        RectTransform rt = dragIcon.GetComponent<RectTransform>();            //RectTransform -> 화면 크기 변화에 따라 UI가 유동적으로 반응
        rt.sizeDelta = new Vector2(80, 80);

    }

    //드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        if (dragIcon != null)
            dragIcon.transform.position = eventData.position;

    }

    //드래그 종료
    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragIcon != null)
            Destroy(dragIcon);
    }

    //다른 슬롯 위로 드롭됨
    public void OnDrop(PointerEventData eventData)
    {
        CraftingSlotUI fromCrafting = eventData.pointerDrag?.GetComponent<CraftingSlotUI>();
        if (fromCrafting != null)
        {
            SwapCraftingSlots(fromCrafting);
            return;
        }

        InventorySlotUI fromInventory = eventData.pointerDrag?.GetComponent<InventorySlotUI>();
        if (fromInventory != null)
        {
            MoveItemFromInventory(fromInventory);
            return;
        }
    }

    private void SwapCraftingSlots(CraftingSlotUI from)
    {
        ItemSO oldItem = craftingSlot.item;
        int oldCount = craftingSlot.count;

        craftingSlot.item = from.craftingSlot.item;
        craftingSlot.count = from.craftingSlot.count;

        from.craftingSlot.item = oldItem;
        from.craftingSlot.count = oldCount;

        RefreshUI();
        from.RefreshUI();
    }

    private void MoveItemFromInventory(InventorySlotUI invSlotUI)
    {
       if(craftingSlot.item  !=null)
        {
            Debug.Log("작업대 슬롯이 비어있지 않습니다.");
            return;
        }

        ItemSO moveItem = invSlotUI.linkedSlot.item;
        int moveCount = invSlotUI.linkedSlot.count;

        if (moveItem == null) return;

        craftingSlot.SetItem(moveItem, moveCount);
        RefreshUI();

        invSlotUI.linkedSlot.Clear();
        invSlotUI.RefreshUI();
    }

}
