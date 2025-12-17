using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    public static CraftingUI Instance;

    public InventorySlot materialA;
    public InventorySlot materialB;

    public ItemSO resultItem;

    private void Awake()
    {
        Instance = this;
        materialA = new InventorySlot();
        materialB = new InventorySlot();
    }

    public void TryAddMaterial(InventorySlot fromSlot)
    {
        if (materialA.item == null)
            MoveItem(fromSlot, materialA);
        else if (materialB.item == null)
            MoveItem(fromSlot, materialB);
    }

    void MoveItem(InventorySlot from, InventorySlot to)
    {
        to.item = from.item;
        to.count = 1;
        from.count--;
        if (from.count <= 0) from.Clear();
    }

    public void Craft()
    {
        if (materialA.item == null || materialB.item == null) return;

        Inventory inv = FindObjectOfType<Inventory>();
        inv.AddItem(resultItem, 1);

        QuestManager.Instance.OnCraft(resultItem);

        materialA.Clear();
        materialB.Clear();
    }
}
