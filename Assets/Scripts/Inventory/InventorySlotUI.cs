using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [Header("실제 데이터 슬롯")]
    public InventorySlot linkedSlot;

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
        if (linkedSlot.item == null || linkedSlot.count <=0)
        {
            itemIcon.enabled = false;
            itemCountText.text = "";
        }
        else
        {
            itemIcon.enabled = true;
            itemIcon.sprite = linkedSlot.item.icon;
            itemCountText.text = linkedSlot.count.ToString();
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (linkedSlot.item == null) return;

        dragIcon = new GameObject("DragIcon");
        dragIcon.transform.SetParent(canvas);
        dragIcon.transform.SetAsLastSibling();

        Image img = dragIcon.AddComponent<Image>();
        img.sprite = linkedSlot.item.icon;
        img.raycastTarget = false;

        RectTransform rt = dragIcon.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(80, 80);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragIcon != null)
            Destroy(dragIcon);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragIcon != null)
            Destroy(dragIcon);
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventorySlotUI fromInventory = eventData.pointerDrag?.GetComponent<InventorySlotUI>();
        CraftingSlotUI fromCrafting = eventData.pointerDrag?.GetComponent<CraftingSlotUI>();

        if(fromInventory !=null)
        {
            SwapSlots(fromInventory);
            return;
        }

        if (fromCrafting !=null)
        {
            return;
        }
        
    }

    private void SwapSlots(InventorySlotUI other)
    {
        ItemSO tempItem = linkedSlot.item;
        int tempCount = linkedSlot.count;

        linkedSlot.item = other.linkedSlot.item;
        linkedSlot.count = other.linkedSlot.count;

        other.linkedSlot.item = tempItem;
        other.linkedSlot.count = tempCount;

        RefreshUI();
        other.RefreshUI();

    }

}
