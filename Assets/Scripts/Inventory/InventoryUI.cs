using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("인벤토리 참조")]
    public Inventory inventory;

    [Header("한 줄 UI 슬롯들")]
    public Image[] smallSlotImages;
    public Text[] smallSlotCounts;

    [Header("선택된 슬롯 강조 UI")]
    public Image[] slotHighlights;

    [Header("큰 인벤토리 UI")]
    public GameObject bigInventoryPanel;

    private bool isOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))      //E 키를 눌렀을 때
        {
            isOpen = !isOpen;
            bigInventoryPanel.SetActive(isOpen);            //큰 인벤토리 패널 열기
        }

        HandleSelectSlotInput();
        UpdateSmallUI();
    }

    void HandleSelectSlotInput()
    {
       // if (Input.GetKeyDown(KeyCode.Alpha1)) inventory.SelectSlot(0);
       // if (Input.GetKeyDown(KeyCode.Alpha2)) inventory.SelectSlot(1);
       // if (Input.GetKeyDown(KeyCode.Alpha3)) inventory.SelectSlot(2);              = 이전 코드들인데 사실.. 너무 노가다고 람다식 생각나서 물어봤는데
       // if (Input.GetKeyDown(KeyCode.Alpha4)) inventory.SelectSlot(3);                 for문으로 하는게 더 편하다는 걸 알아버린 나.
        //if (Input.GetKeyDown(KeyCode.Alpha5)) inventory.SelectSlot(4);

        for (int i = 0; i < inventory.slots.Count; i++)
        {
            KeyCode key = KeyCode.Alpha1 + i;

            if(Input.GetKeyDown(key))
            {
                inventory.SelectSlot(i);
                break;
            }
        }
    } 

    void UpdateSmallUI()
    {
        for (int i = 0; i < smallSlotImages.Length; i++)
        {
            if (i < inventory.slots.Count && inventory.slots[i].item !=null)
            {
                smallSlotImages[i].sprite = inventory.slots[i].item.icon;
                smallSlotCounts[i].text = inventory.slots[i].count.ToString();
                smallSlotImages[i].enabled = true;
            }
            else
            {
                smallSlotImages[i].enabled = false;
                smallSlotCounts[i].text = "";
            }

            slotHighlights[i].enabled = (i == inventory.selectedSlotIndex);
        }
    }
}
