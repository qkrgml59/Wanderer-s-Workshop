using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGather : MonoBehaviour
{
    public float gatherDistance = 3f;
    public LayerMask blockLayer;
    public int baseDamage = 1;

    public float interactDistance = 5f;

    Camera cam;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ÁÂÅ¬¸¯
        {
            TryGather();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            TryInteract();
        }
    }

    void TryGather()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, gatherDistance))
        {
            if (hit.collider.TryGetComponent<Block>(out Block block))
            {
                block.Hit((int)PlayerStats.Instance.gatherDamage);
            }
            else if (hit.collider.TryGetComponent<PlaceableObject>(out PlaceableObject place))
            {
                place.Hit((int)PlayerStats.Instance.gatherDamage);
            }
        }
    }

    void TryPlaceItem()
    {
        Inventory inv = Inventory.Instance; 
        InventorySlot slot = inv.slots[inv.selectedSlotIndex];

        if (slot.item == null) return;
        if (!slot.item.isPlaceable) return;
        if (slot.item.placePrefab == null) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            Vector3 pos = hit.point + hit.normal * 0.5f;
            pos = Vector3Int.RoundToInt(pos);

            Instantiate(slot.item.placePrefab, pos, Quaternion.identity);
            inv.RemoveItem(slot.item, 1);
        }
    }

    void TryInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2)
        );

        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            if (hit.collider.TryGetComponent<WorkBench>(out WorkBench workbench))
            {
                workbench.Toggle();
            }
        }
    }
}
