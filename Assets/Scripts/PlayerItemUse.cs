using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemUse : MonoBehaviour
{
    public Inventory inventory;
    public Camera cam;
    public float placeDistance = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            TryUseItem();
        }
    }

    void TryUseItem()
    {
        var slot = inventory.slots[inventory.selectedSlotIndex];
        if (slot.item == null || slot.count <= 0) return;

        ItemSO item = slot.item;

        if (item.isPlaceable)
        {
            TryPlace(item);
            slot.count--;

            if (slot.count <= 0)
                slot.item = null;
        }
    }

    void TryPlace(ItemSO item)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, placeDistance))
        {
            Vector3 pos = hit.point;
            pos = new Vector3(
                Mathf.Round(pos.x),
                Mathf.Round(pos.y),
                Mathf.Round(pos.z)
            );

            Instantiate(item.placePrefab, pos, Quaternion.identity);
        }
    }
}
